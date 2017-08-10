using IndigoVergeTask.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndigoVergeTask.Providers
{
    public class Parser : IParser
    {
        public List<int> ParseConsoleInput(string input)
        {
            var result = input.Split(' ').Select(Int32.Parse).ToList();

            return result;
        }
    }
}
