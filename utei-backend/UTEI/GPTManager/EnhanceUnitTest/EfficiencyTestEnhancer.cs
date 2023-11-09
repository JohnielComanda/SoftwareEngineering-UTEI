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

        public async Task<string> Enhancer(string progLang, string unitTest)
        {
            var prompt = $"Write an improved version of the following unit test method using {progLang}:\n\n```\n{unitTest}\n``` that adheres to the proper conventions of writing proper unit test.";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> SuggestionGenerator(string unitTest)
        {
            var prompt = $"Write a detailed list of recommendations regarding the unit test input: ```\n{unitTest}\n``` on how to improve if there's a lacking in it's runtime/compiletime, unit test code efficiency, and how to make it follow the conventions of writing proper unit test. return just the list. And write an improved version of the following unit test```\n{unitTest}\n``` that adheres to the proper conventions of writing proper unit test. Concatenate the two output using '+'";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
