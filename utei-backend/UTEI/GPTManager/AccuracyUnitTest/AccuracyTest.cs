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
            var prompt = $"Given this unit test:\n```\n{unitTest}\n```\nEstimate the performance of the unit test in terms of:\n\n" +
              $"Execution Time: Provide an estimated execution time in milliseconds.\n" +
              $"Isolated: Provide an estimate of how isolated the unit test is, represented as a percentage.\n" +
              $"Code Coverage: Provide an estimate of code coverage achieved by the unit test, represented as a percentage.\n" +
              $"Maintainability: Provide an estimate of the maintainability of the unit test, represented as a percentage.\n" +
              $"Test Data: Provide a brief explanation of the test data being used.\n" +
              $"Memory Usage: Provide an estimated memory usage in megabytes.\n\n" +
              $"All response should have a straight to the point output and don't give responses such as 'cannot be measured'.";
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }

        public async Task<string> TestCases(AccuracyTestDto accuInfo)
        {
            string prompt;
            if(accuInfo.UnitTestType!.Equals("Multi Dependency"))
            {
                string depen = accuInfo.Dependency1 + accuInfo.Dependency2;
                prompt = $"Given this {accuInfo.ProgrammingLanguage}:'''\n{accuInfo.UnitTest}\n''' and the based method: '''\n{accuInfo.BaseMethod}\n''' and these dependencies: '''\n{depen}\n''' only return pass or fail, expected output, actual result. The output should look like this Pass or Fail + Expected Output Value Only + Actual Output Value Only. For example, 'Pass + 42 + 42'.";
            }
            else
            {
                prompt = $"Given this {accuInfo.ProgrammingLanguage}:'''\n{accuInfo.UnitTest}\n''' and the based method: '''\n{accuInfo.BaseMethod}\n''', please provide the test outcome, expected output, and actual output, separated by '+'. The expected format is: Pass or Fail + Expected Output + Actual Output. For example, 'Pass + 42 + 42'.";

            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
