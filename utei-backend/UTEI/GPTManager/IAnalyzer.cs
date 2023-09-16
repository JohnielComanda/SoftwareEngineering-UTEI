namespace UTEI.GPTManager
{
    public interface IAnalyzer
    {
        Task<string> Analyze(string unitTest);
        Task<string> EvaluateTest(string unitTest);
    }
}
