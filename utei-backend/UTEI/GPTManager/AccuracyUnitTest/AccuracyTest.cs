using System.Globalization;
using UTEI.Dtos;

namespace UTEI.GPTManager.AccuracyUnitTest
{
    public class AccuracyTest : IAccuracyTest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccuracyTest(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Enhancer(string progLang, string unitTest)
        {
            var prompt = $"Write an improved version of the following unit test method using {progLang}:\n\n```\n{unitTest}\n``` that adheres to the proper conventions of writing proper unit test.";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> Recommendations(string unitTest)
        {
            var prompt = $"Write a detailed list of recommendations regarding the unit test input: ```\n{unitTest}\n``` on how to improve if there's a lacking in it's runtime/compiletime, unit test code efficiency, and how to make it follow the conventions of writing proper unit test. return just the list";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> Summary(string unitTest)
        {
            var prompt = $"Write a detailed summary of the unit test method depending on it's estimated performance including it's runtime, compile time, unit test code efficiency, and adherence to writing of a proper unit test```\n{unitTest}\n```. return also a detailed summary of each criteria";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> TestCases(AccuracyTestDto accuInfo)
        {
            string prompt;
            if(accuInfo.UnitTestType.Equals("Multi Dependency"))
            {
                string depen = accuInfo.Dependency1 + accuInfo.Dependency2;
                prompt = $"1 word pass or fail given this {accuInfo.ProgrammingLanguage}:'''\n{accuInfo.UnitTest}\n''' and the based method: '''\n{accuInfo.BaseMethod}\n''' and these dependencies: '''\n{depen}\n''' only return one word pass or fail";
            }
            else
            {
                prompt = $"1 word pass or fail given this {accuInfo.ProgrammingLanguage}:'''\n{accuInfo.UnitTest}\n''' and the based method: '''\n{accuInfo.BaseMethod}\n'''";
            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
