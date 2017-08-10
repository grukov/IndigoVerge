using IndigoVergeTask.Contracts;
using System;
using System.Collections.Generic;

namespace IndigoVergeTask.Providers
{
    public class Printer : IPrinter
    {
        public IWriter writer;
        public IReader reader;

        public Printer(IWriter writer, IReader reader)
        {
            this.writer = writer ?? throw new NullReferenceException("Writer cannot be null!");
            this.reader = reader ?? throw new NullReferenceException("Reader cannot be null!");
        }

        public void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    writer.Write(string.Format("{0} ", matrix[i, j]));
                }
                writer.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public void PrintColoursOccurs(int[,] matrix)
        {
            SortedList<int, int> colorsOccurs = new SortedList<int, int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int colour = matrix[i, j];
                    if (!colorsOccurs.ContainsKey(colour))
                    {
                        colorsOccurs.Add(colour, 1);
                    }
                    else
                    {
                        colorsOccurs[colour]++;
                    }
                }
            }

            foreach (var colour in colorsOccurs)
            {
                writer.WriteLine(string.Format("{0} {1}", colour.Key, colour.Value));
            }
        }
    }
}
