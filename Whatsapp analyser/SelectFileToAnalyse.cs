using System;
using System.Windows.Forms;
using System.IO;

namespace Whatsapp_analyser
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms.DataVisualization.Charting;
    public partial class SelectFileToAnalyse : Form
    {
        //todo : Refactor the logic of this class to an analyser class
        private Dictionary<string, List<Message>> _messages;
        public SelectFileToAnalyse()
        {
            InitializeComponent();
            _messages = new Dictionary<string, List<Message>>();
            VisualChart.ChartAreas[0].InnerPlotPosition.Height = 100;
            VisualChart.ChartAreas[0].InnerPlotPosition.Width = 100;
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            FileDialog selectFileToOpenDialog = new OpenFileDialog();

            DialogResult result = selectFileToOpenDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            string fileLocation = selectFileToOpenDialog.FileName;
            StreamReader whatsappFile = File.OpenText(fileLocation);

            AnalyseFile(whatsappFile);


        }


        private void AnalyseFile(StreamReader file)
        {
            _messages.Clear();
            const int beginIndex = 18;
            const int dayIndex = 0;
            const int monthIndex = 3;
            const int yearIndex = 6;
            const int hourIndex = 10;
            const int minuteIndex = 13;
            const int numberLenght = 2;

            int messageIndex = 0;
            _messages.Add("NVOK", new List<Message>());
            while (!file.EndOfStream)
            {
                try // todo The application can't handle the fact that some messages are multi-line. Not importent right now because the data is still accurate
                {
                    string line = file.ReadLine();

                    int endIndex = line.IndexOf(":", line.IndexOf(":") + 1);
                    string sender = line.Substring(18, endIndex - beginIndex);

                    string content = line.Substring(endIndex + 1);

                    int day = Convert.ToInt32(line.Substring(dayIndex, numberLenght));
                    int month = Convert.ToInt32(line.Substring(monthIndex, numberLenght));
                    int year = Convert.ToInt32(line.Substring(yearIndex, numberLenght));
                    int hour = Convert.ToInt32(line.Substring(hourIndex, numberLenght));
                    int minute = Convert.ToInt32(line.Substring(minuteIndex, numberLenght));

                    Message message = new Message(messageIndex, content, minute, hour, day, month, year);

                    if (_messages.ContainsKey(sender))
                    {
                        _messages[sender].Add(message);
                    }
                    else
                    {
                        _messages.Add(sender, new List<Message>());
                        _messages[sender].Add(message);
                    }
                    messageIndex++;
                }
                catch (Exception exception)
                {
                    _messages["NVOK"].Add(new Message(exception.ToString()));
                }
            }
            foreach (KeyValuePair<string, List<Message>> keyValuePair in _messages)
            {
                Console.WriteLine(keyValuePair.Key + keyValuePair.Value.Count);
            }
        }

        private void BtnMessagePersonRate_Click(object sender, EventArgs e)
        {
            VisualChart.Series.Clear();
            VisualChart.Titles.Clear();

            string[] seriesArray = _messages.Keys.ToArray();
            seriesArray[0] = "Total";

            int[] pointsArray = new int[_messages.Keys.Count];

            int j = 0;
            foreach (KeyValuePair<string, List<Message>> keyValuePair in _messages)
            {
                pointsArray[j] = keyValuePair.Value.Count;
                j++;
            }
            pointsArray[0] = pointsArray.Sum();

            // Set the view model chart with data
            VisualChart.Titles.Add("Message per person");

            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = VisualChart.Series.Add(seriesArray[i]);
                series.Points.AddXY(seriesArray[i], pointsArray[i]);
                series.LegendText = seriesArray[i] + ": " + pointsArray[i];
            }
        }

        private void BtnMessagePerHour_Click(object sender, EventArgs e)
        {
            VisualChart.Series.Clear();
            VisualChart.Titles.Clear();

            Dictionary<int, int> countPerHour = new Dictionary<int, int>();
            for (int i = 0; i < 24; i++)
            {
                countPerHour.Add(i, 0);
            }

            // todo Opportunity to expand the application so the user can get msg per hour per person.
            foreach (KeyValuePair<string, List<Message>> keyValuePair in _messages)
            {
                if (keyValuePair.Key != "NVOK")
                {
                    List<Message> currentMessages = keyValuePair.Value;
                    foreach (Message message in currentMessages)
                    {
                        countPerHour[message.DateTime.Hour]++;
                    }
                }
            }
            string[] seriesArray = countPerHour.Keys.ToArray().Select(x => x.ToString()).ToArray();
            int[] pointsArray = countPerHour.Values.ToArray();

            VisualChart.Titles.Add("Messages per hour");

            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = VisualChart.Series.Add(seriesArray[i]);
                series.Points.AddXY(seriesArray[i], pointsArray[i]);
                series.LegendText = seriesArray[i] + ": " + pointsArray[i];
            }
        }
    }
}
