namespace UTEI.GPTManager
{
    public interface IAnalyzer
    {
        Task<string> Analyze(string progLang, string unitTest);
        Task<string> EvaluateTest(string input);
    }
}
