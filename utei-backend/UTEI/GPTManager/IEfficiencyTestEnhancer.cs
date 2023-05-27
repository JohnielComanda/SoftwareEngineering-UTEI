namespace UTEI.GPTManager
{
    public interface IEfficiencyTestEnhancer
    {
        Task<string> Enhancer(string progLang, string unitTest);
        Task<string> SuggestionGenerator();
    }
}
