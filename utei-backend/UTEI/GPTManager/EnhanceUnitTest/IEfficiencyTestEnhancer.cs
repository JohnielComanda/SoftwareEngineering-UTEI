namespace UTEI.GPTManager.EnhanceUnitTest
{
    public interface IEfficiencyTestEnhancer
    {
        /// <summary>
        /// This is for requesting a response from OpenAI to Generate an enhanced version of a unit test 
        /// </summary>
        /// <param name="progLang">Programming language used by the unit test</param>
        /// <param name="unitTest">UnitTest code to enhance</param>
        /// <returns>Returns the response from OpenAI given the prompt for enhancing a unit test</returns>
        Task<string> Enhancer(string progLang, string unitTest);

        /// <summary>
        /// This is for requesting a response from OpenAI to Generate an suggestion for improving a unit test 
        /// </summary>
        /// <param name="unitTest">Unit test to generate a suggestion</param>
        /// <returns>Returns the response from OpenAI given the prompt for generating suggestions for a unit test</returns>
        Task<string> SuggestionGenerator(string unitTest);
    }
}
