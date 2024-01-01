using UTEI.Dtos;

namespace UTEI.GPTManager.AccuracyUnitTest
{
    public interface IAccuracyTest
    {
        Task<string> Enhancer(string progLang, string unitTest);
        Task<string> Recommendations(string unitTest);
        Task<string> Summary(string unitTest);
        Task<string> TestCases(AccuracyTestDto accuInfo);
    }
}
