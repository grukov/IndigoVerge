using IndigoVergeTask.Contracts;
using System;
using System.IO.MemoryMappedFiles;

namespace IndigoVergeTask
{
    public class Engine
    {
        public IReader reader;
        public IWriter writer;
        public IPrinter printer;
        public IParser parser;
        public ILogger logger;

        private static Engine instance;

        private Engine(IReader reader, IWriter writer, IPrinter printer, IParser parser, ILogger logger)
        {
            this.reader = reader ?? throw new NullReferenceException("Reader cannot be null!");
            this.writer = writer ?? throw new NullReferenceException("Writer cannot be null!");
            this.printer = printer ?? throw new NullReferenceException("Printer cannot be null!");
            this.parser = parser ?? throw new NullReferenceException("Parser cannot be null!");
            this.logger = logger ?? throw new NullReferenceException("Logger cannot be null!");
        }

        public static Engine Instance(IReader reader, IWriter writer, IPrinter printer, IParser parser, ILogger logger)
        {
            if (instance == null)
            {
                instance = new Engine(reader, writer, printer, parser, logger);
            }

            return instance;
        }

        public void Start()
        {
            try
            {
                string sheetDimensions = reader.ReadLine();
                var parsedSheetInput = parser.ParseConsoleInput(sheetDimensions);

                int sheetWidth = parsedSheetInput[0];
                int sheetHeight = parsedSheetInput[1];

                var data = MemoryMappedFile.CreateNew("big data", sheetWidth * sheetHeight);
                var view = data.CreateViewAccessor();

                int[,] sheet = new int[sheetHeight, sheetWidth];

                while (true)
                {
                    string inputLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(inputLine))
                    {
                        break;
                    }
                    var parsedColorSheetInput = parser.ParseConsoleInput(inputLine);

                    int colour = parsedColorSheetInput[0];
                    int startY = parsedColorSheetInput[1];
                    int startX = parsedColorSheetInput[2];
                    int height = parsedColorSheetInput[3];
                    int width = parsedColorSheetInput[4];

                    for (int i = startX; i < startX + width; i++)
                    {
                        for (int j = startY; j < startY + height; j++)
                        {
                            sheet[i,j] = colour;
                        }
                    }
                }

                printer.PrintMatrix(sheet);
                printer.PrintColoursOccurs(sheet);
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                writer.WriteLine(ex.Message);
            }
        }
    }
}
