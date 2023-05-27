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
            var prompt = $"Write a summary of the code on how efficient it is and how it adheres to the conventions of writing proper unit test for this unit test method::```\n{unitTest}\n```";
            return await GPTRequestHandler.RequestHandler(prompt);
        }

        public Task<string> EvaluateTest(string input)
        {
            throw new NotImplementedException();
        }
    }
}
