using System.Text.Json;
using UTEI.Models;

namespace UTEI.GPTManager.EnhanceUnitTest
{
    public class Analyzer : IAnalyzer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Analyzer(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// This is for requesting a response from OpenAI to Analyze a unit test 
        /// </summary>
        /// <param name="unitTest">Unit test to analyze</param>
        /// <returns>Returns the response from OpenAI given the prompt for analyzing unit test</returns>
        public async Task<string> Analyze(string unitTest)
        {
            string prompt = "respond with: Cannot Analyze unit test with the given input!";
            if (unitTest.Length > 20)
            {
                prompt = $"Write a detailed summary and suggestion of the unit test method, considering its estimated performance including runtime, compile time, unit test code efficiency, and adherence to writing a proper unit test.\n\n" +
                         $"Unit Test Method:\n{unitTest}\n\n" +
                         $"Return a detailed summary of each criterion and separate the summary and suggestion using '$' between the two before the suggestion output.";


            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        /// <summary>
        /// This is for requesting a response from OpenAI to Evaluate a unit test 
        /// </summary>
        /// <param name="unitTest">Unit test to evaluate</param>
        /// <returns>Returns the response from OpenAI given the prompt for evaluating unit test</returns>
        public async Task<string> EvaluateTest(string unitTest)
        {
            string prompt = "respond with: Cannot Evaluate unit test with the given input!";
            if (unitTest.Length > 20)
            {
                prompt = $"Rate this unit test :```\n{unitTest}\n``` very strictly on a scale of 5 where 5 means very high performing, 4 means high, 3 means has room for improvement, 2 means low, and 1 very low. The criteria is it's estimated runtime, compile time, unit test code efficiency, and adherence to writing of a proper unit test. reply with just number 1 to 5 and nothing else";

            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
