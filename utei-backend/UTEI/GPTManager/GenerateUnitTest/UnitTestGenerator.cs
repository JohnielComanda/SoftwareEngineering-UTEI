using Amazon.Runtime;

namespace UTEI.GPTManager.GenerateUnitTest
{
    public class UnitTestGenerator : IUnitTestGenerator
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UnitTestGenerator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// This is for requesting a response from OpenAI to generate a unit test 
        /// </summary>
        /// <param name="progLang">Programming language use for the method and unit test</param>
        /// <param name="baseMethod">Method to create a unit test</param>
        /// <returns>Returns the response from OpenAI given the prompt for generating unit test</returns>
        public async Task<string> Generator(string progLang, string baseMethod, string frameWork)
        {
            string prompt = "respond with: Cannot generate unit test with the given input!";
            if (baseMethod.Length > 20)
            {
                prompt = $"Generate a complete usable unit test given the method:```\\n{baseMethod}\\n```using ```\\n{progLang} and {frameWork}\\n```that adheres to the proper conventions of writing unit test and return just the unit test ready and usable for working codebase that has an import statements and without any additional information and comments. If the method is not unit testable just respond with -1 with no other information and comments\"";

            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
