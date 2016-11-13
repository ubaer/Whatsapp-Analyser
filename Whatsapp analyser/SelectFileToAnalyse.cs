// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectFileToAnalyse.cs" company="TvJ">
// Yes.
// </copyright>
// <summary>
//   Defines the SelectFileToAnalyse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Whatsapp_analyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;

    using Whatsapp_analyser.FileAnalyser;
    using Message;

    /// <summary>
    /// Controller for the GUI that shows chat information
    /// </summary>
    public partial class SelectFileToAnalyse : Form
    {
        private readonly WhatsappFileAnalyserV1 _analyser;
        public SelectFileToAnalyse()
        {
            InitializeComponent();
            _analyser = new WhatsappFileAnalyserV1();
            VisualChart.Enabled = true;
            //  VisualChart.ChartAreas[0].InnerPlotPosition.Height = 100;
            // VisualChart.ChartAreas[0].InnerPlotPosition.Width = 100;
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

            _analyser.AnalyseFile(whatsappFile);

            SetFirstMessageDate(_analyser.GetFirstMessageDateTime());
            _analyser.GetAmountOfMessagesPerDate();
        }

        private void SetFirstMessageDate(MessageDateTime messageDateTime)
        {
            string hour;
            string minute;

            hour = messageDateTime.Hour < 10 ? "0" + messageDateTime.Hour : messageDateTime.Hour.ToString();
            minute = messageDateTime.Minute < 10 ? "0" + messageDateTime.Minute : messageDateTime.Minute.ToString();

            string dateTime = $"{messageDateTime.Day}-{messageDateTime.Month}-{messageDateTime.Year} {hour}:{minute}";
            LblFirstMessage.Text = dateTime;
        }

        private void BtnMessagePersonRate_Click(object sender, EventArgs e)
        {
            // Prepare the viewmodel with data
            if (VisualChart.Legends.Count < 1)
            {
                VisualChart.Legends.Add("");
            }
            VisualChart.Series.Clear();
            VisualChart.Titles.Clear();
            VisualChart.Titles.Add("Message per person");

            Dictionary<string, int> amountOfMessagesPerPerson = _analyser.GetAmountOfMessagesPerPerson();

            string[] seriesArray = amountOfMessagesPerPerson.Keys.ToArray();
            seriesArray[0] = "Total";

            int[] pointsArray = amountOfMessagesPerPerson.Values.ToArray();
            pointsArray[0] = pointsArray.Sum();

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = VisualChart.Series.Add(seriesArray[i]);
                series.Points.AddXY(seriesArray[i], pointsArray[i]);
                series.LegendText = seriesArray[i] + ": " + pointsArray[i];
            }

        }

        private void BtnMessagePerHour_Click(object sender, EventArgs e)
        {
            if (VisualChart.Legends.Count < 1)
            {
                VisualChart.Legends.Add("");
            }
            VisualChart.Series.Clear();
            VisualChart.Titles.Clear();
            VisualChart.Titles.Add("Messages per hour");

            Dictionary<int, int> messagePerHour = _analyser.GetMessagesPerHour();

            string[] seriesArray = messagePerHour.Keys.ToArray().Select(x => x.ToString()).ToArray();
            int[] pointsArray = messagePerHour.Values.ToArray();


            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = VisualChart.Series.Add(seriesArray[i]);
                series.Points.AddXY(seriesArray[i], pointsArray[i]);
                series.LegendText = seriesArray[i] + ": " + pointsArray[i];
                series["PointWidth"] = "1.5";
            }
        }

        private void btnMessagePerDay_Click(object sender, EventArgs e)
        {
            VisualChart.Series.Clear();
            VisualChart.Titles.Clear();
            VisualChart.Titles.Add("Messages per day");

            Dictionary<string, int> messagePerDate = _analyser.GetAmountOfMessagesPerDate();

            string[] seriesArray = messagePerDate.Keys.ToArray().Select(x => x.ToString()).ToArray();
            int[] pointsArray = messagePerDate.Values.ToArray();


            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = VisualChart.Series.Add(seriesArray[i]);
                series.Points.AddXY(seriesArray[i], pointsArray[i]);
                series["PointWidth"] = "1.5";
            }
            VisualChart.Legends.Clear();
        }
    }
}
