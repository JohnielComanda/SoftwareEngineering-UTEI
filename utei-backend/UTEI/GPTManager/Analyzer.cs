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
            var prompt = $"Write a detailed summary of the unit test method depending on it's estimated performance including it's runtime, compile time, unit test code efficiency, and adherence to writing of a proper unit test```\n{unitTest}\n```. return also a detailed summary of each criteria";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> EvaluateTest(string unitTest)
        {
            var prompt = $"Rate this unit test :```\n{unitTest}\n``` very strictly on a scale of 5 where 5 means very high performing, 4 means high, 3 means has room for improvement, 2 means low, and 1 very low. The criteria is it's estimated runtime, compile time, unit test code efficiency, and adherence to writing of a proper unit test. reply with just number 1 to 5 and nothing else";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
