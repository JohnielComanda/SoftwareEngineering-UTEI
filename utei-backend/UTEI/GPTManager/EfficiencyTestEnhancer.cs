using System.Text.Json;
using UTEI.Models;

namespace UTEI.GPTManager
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
            var prompt = $"Write an improved version of the following unit test method:\n\n```{progLang}\n{unitTest}\n```";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> SuggestionGenerator(string unitTest)
        {
            var prompt = $"Write suggestions for the code to improve it's efficiency and the conventions of writing proper unit test for this unit test method:```\n{unitTest}\n```";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
