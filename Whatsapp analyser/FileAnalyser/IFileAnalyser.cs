namespace Whatsapp_analyser.FileAnalyser
{
    using System.Collections.Generic;
    using System.IO;

    using Whatsapp_analyser.Message;

    public interface IFileAnalyser
    {
        void AnalyseFile(StreamReader file);

        Dictionary<string, int> GetAmountOfMessagesPerPerson();

        Dictionary<int, int> GetMessagesPerHour();

        MessageDateTime GetFirstMessageDateTime();
    }
}