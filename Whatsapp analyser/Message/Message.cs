namespace Whatsapp_analyser.Message
{
    public class Message
    {
        private int _index;
        private MessageDateTime _dateTime;

        public string _content;

        public Message(int index, string content, int minute, int hour, int day, int month, int year)
        {
            _index = index;
            _content = content;
            _dateTime.Minute = minute;
            _dateTime.Hour = hour;
            _dateTime.Day = day;
            _dateTime.Month = month;
            _dateTime.Year = year;
        }

        public Message(string content)
        {
            _content = content;
        }

        public Message()
        {
            
        }

        public int Index => _index;

        public string Content => _content;
        public MessageDateTime DateTime => _dateTime;
    }
}