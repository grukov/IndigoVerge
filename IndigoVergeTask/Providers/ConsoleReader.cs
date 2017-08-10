using IndigoVergeTask.Contracts;
using System;

namespace IndigoVergeTask.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
