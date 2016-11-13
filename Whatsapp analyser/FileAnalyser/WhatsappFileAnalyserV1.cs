namespace Whatsapp_analyser.FileAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;

    using Whatsapp_analyser.Message;

    public class WhatsappFileAnalyserV1 : IFileAnalyser
    {
        private Dictionary<string, List<Message>> _messages;

        private Message _lastMessage;

        public WhatsappFileAnalyserV1()
        {
            _messages = new Dictionary<string, List<Message>>();
        }

        public void AnalyseFile(StreamReader file)
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
            Message message = new Message();
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

                    message = new Message(messageIndex, content, minute, hour, day, month, year);

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
            _lastMessage = message;
            foreach (KeyValuePair<string, List<Message>> keyValuePair in _messages)
            {
                Console.WriteLine(keyValuePair.Key + keyValuePair.Value.Count);
            }
        }

        public MessageDateTime GetFirstMessageDateTime()
        {
            string firstKey = _messages.Keys.ToArray()[1];
            Message firstMessage = _messages[firstKey].First();
            return firstMessage.DateTime;
        }

        public Dictionary<int, int> GetMessagesPerHour()
        {
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
            return countPerHour;
        }

        public Dictionary<string, int> GetAmountOfMessagesPerPerson()
        {
            Dictionary<string, int> amountOfMessagesPerPerson = new Dictionary<string, int>();

            foreach (KeyValuePair<string, List<Message>> keyValuePair in _messages)
            {
                amountOfMessagesPerPerson.Add(keyValuePair.Key, keyValuePair.Value.Count);
            }

            return amountOfMessagesPerPerson;
        }

        public Dictionary<string, int> GetAmountOfMessagesPerDate()
        {
            // todo Maybe the string date can be replaced with something else because now all the messages will do a tostring function
            Dictionary<string, int> amountOfMessagesPerDate = new Dictionary<string, int>();

            // todo Cross year doensn't work
            MessageDateTime firstMessageDateTime = GetFirstMessageDateTime();
            int year = 2000 + firstMessageDateTime.Year;
            for (int month = firstMessageDateTime.Month; month<= _lastMessage.DateTime.Month; month++)
            {
                int daysInMonth = DateTime.DaysInMonth(year, month);
                for (int i = 1; i <= daysInMonth; i++)
                {
                    amountOfMessagesPerDate.Add($"{i}-{month}-{firstMessageDateTime.Year}",0);
                }
            }

            foreach (KeyValuePair<string, List<Message>> keyValuePair in _messages)
            {
                if (keyValuePair.Key != "NVOK")
                {
                    foreach (Message message in keyValuePair.Value)
                    {
                        amountOfMessagesPerDate[message.DateTime.GetDate()]++;
                    }
                }
            }


            return amountOfMessagesPerDate;
        }
    }
}