namespace UTEI.GPTManager.EnhanceUnitTest
{
    public interface IAnalyzer
    {
        /// <summary>
        /// This is for requesting a response from OpenAI to Analyze a unit test 
        /// </summary>
        /// <param name="unitTest">Unit test to analyze</param>
        /// <returns>Returns the response from OpenAI given the prompt for analyzing unit test</returns>
        Task<string> Analyze(string unitTest);

        /// <summary>
        /// This is for requesting a response from OpenAI to Evaluate a unit test 
        /// </summary>
        /// <param name="unitTest">Unit test to evaluate</param>
        /// <returns>Returns the response from OpenAI given the prompt for evaluating unit test</returns>
        Task<string> EvaluateTest(string unitTest);
    }
}
