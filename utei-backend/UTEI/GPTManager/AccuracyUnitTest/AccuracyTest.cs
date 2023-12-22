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
            var prompt = $"Given this unit test```\n{unitTest}\n```. Measure the performance of unit test in terms of: \r\n\r\nExecution Time: \"Answer this in number\"\r\nIsolated: \"Answer this in percentage\"\r\nCode Coverage: \"Answer this in percentage\"\r\nMaintainability: \"Answer this in percentage\"\r\nTest Data: \"give a brief explanation here\"\r\nMemory Usage: \"Answer this in numbers\"\r\n\r\nConclusion: \"If it is already efficient and accurate.";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> TestCases(AccuracyTestDto accuInfo)
        {
            string prompt;
            if(accuInfo.UnitTestType.Equals("Multi Dependency"))
            {
                string depen = accuInfo.Dependency1 + accuInfo.Dependency2;
                prompt = $"Given this {accuInfo.ProgrammingLanguage}:'''\n{accuInfo.UnitTest}\n''' and the based method: '''\n{accuInfo.BaseMethod}\n''' and these dependencies: '''\n{depen}\n''' only return pass or fail, expected output, actual result. The output should look like this Pass or Fail + Expected Output Value Only + Actual Output Value Only";
            }
            else
            {
                prompt = $"Given this {accuInfo.ProgrammingLanguage}:'''\n{accuInfo.UnitTest}\n''' and the based method: '''\n{accuInfo.BaseMethod}\n''' only return pass or fail, expected output, actual result. The output should look like this Pass or Fail + Expected Output Value Only + Actual Output Value Only";
            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
