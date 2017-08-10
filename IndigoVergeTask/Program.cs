using IndigoVergeTask.Contracts;
using IndigoVergeTask.Providers;

namespace IndigoVergeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPrinter printer = new Printer(writer, reader);
            IParser parser = new Parser();
            ILogger logger = new FileLogger();

            var engine = Engine.Instance(reader, writer, printer, parser, logger);
            engine.Start();
        }
    }
}
