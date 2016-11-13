using System;

namespace Whatsapp_analyser.Message
{
    public struct MessageDateTime
    {
        public int Minute { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        internal string GetDate()
        {
            return $"{Day}-{Month}-{Year}";
        }
    }
}