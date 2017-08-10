namespace IndigoVergeTask.Contracts
{
    public interface IPrinter
    {
        void PrintMatrix(int[,] matrix);

        void PrintColoursOccurs(int[,] matrix);
    }
}
