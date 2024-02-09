using System.Text.Json;
using UTEI.Models;

namespace UTEI.GPTManager.EnhanceUnitTest
{
    public class EfficiencyTestEnhancer : IEfficiencyTestEnhancer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EfficiencyTestEnhancer(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// This is for requesting a response from OpenAI to Generate an enhanced version of a unit test 
        /// </summary>
        /// <param name="progLang">Programming language used by the unit test</param>
        /// <param name="unitTest">UnitTest code to enhance</param>
        /// <returns>Returns the response from OpenAI given the prompt for enhancing a unit test</returns>
        public async Task<string> Enhancer(string progLang, string unitTest)
        {
            string prompt = "respond with: Cannot Generate unit test with the given input!";
            if (unitTest.Length > 20)
            {
                prompt = $"Write an improved version of the following unit test method using {progLang}:\n\n```\n{unitTest}\n``` that adheres to the proper conventions of writing proper unit test and just respond an improved version without additional information.";
            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        /// <summary>
        /// This is for requesting a response from OpenAI to Generate an suggestion for improving a unit test 
        /// </summary>
        /// <param name="unitTest">Unit test to generate a suggestion</param>
        /// <returns>Returns the response from OpenAI given the prompt for generating suggestions for a unit test</returns>
        public async Task<string> SuggestionGenerator(string unitTest)
        {
            string prompt = "respond with: Cannot Generate unit test suggestions with the given input!";
            if (unitTest.Length > 20)
            {
                prompt = $"Write a detailed list of recommendations regarding the unit test input: ```\n{unitTest}\n``` on how to improve if there's a lacking in it's runtime/compiletime, unit test code efficiency, and how to make it follow the conventions of writing proper unit test. return just the list. And write an improved version of it```\n{unitTest}\n``` that adheres to the proper conventions of writing proper unit test.";
            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
