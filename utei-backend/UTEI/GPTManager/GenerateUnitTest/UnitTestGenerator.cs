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
        public async Task<string> Generator(string progLang, string baseMethod)
        {
            string prompt = "respond with: Cannot generate unit test with the given input!";
            if (baseMethod.Length > 20)
            {
                prompt = $"Generate a complete usable unit test given the method:```\\n{baseMethod}\\n```using ```\\n{progLang}\\n```that adheres to the proper conventions of writing unit test and return just the unit test without any addition information.\"";

            }
            return await GPTRequestHandler.RequestHandler(prompt, _httpClientFactory);
        }
    }
}
