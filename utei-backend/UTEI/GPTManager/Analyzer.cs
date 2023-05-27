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

        public async Task<string> Analyze(string progLang, string unitTest)
        {

        }

        public Task<string> EvaluateTest(string input)
        {
            throw new NotImplementedException();
        }
    }
}
