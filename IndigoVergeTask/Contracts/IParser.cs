using System.Collections.Generic;

namespace IndigoVergeTask.Contracts
{
    public interface IParser
    {
        List<int> ParseConsoleInput(string input);
    }
}
