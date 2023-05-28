using System.Text.Json;
using UTEI.Models;

namespace UTEI.GPTManager
{
    public class Analyzer : IAnalyzer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Analyzer(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Analyze(string unitTest)
        {
            var prompt = $"Write a summary of the code on how efficient it is and how it adheres to the conventions of writing proper unit test for this unit test method:```\n{unitTest}\n```";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> EvaluateTest(string unitTest)
        {
            var prompt = $"rate this unit test on a scale of 5 where 5 means efficient and 1 means inefficient.\r\n\r\nreply with just number 1 to 5 and nothing else:```\n{unitTest}\n```";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
