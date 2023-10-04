namespace UTEI.GPTManager.EnhanceUnitTest
{
    public interface IEfficiencyTestEnhancer
    {
        Task<string> Enhancer(string progLang, string unitTest);
        Task<string> SuggestionGenerator(string unitTest);
    }
}
