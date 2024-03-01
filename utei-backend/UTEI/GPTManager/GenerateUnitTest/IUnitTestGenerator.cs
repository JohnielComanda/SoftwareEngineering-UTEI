namespace UTEI.GPTManager.GenerateUnitTest
{
    public interface IUnitTestGenerator
    {
        /// <summary>
        /// This is for requesting a response from OpenAI to generate a unit test 
        /// </summary>
        /// <param name="progLang">Programming language use for the method and unit test</param>
        /// <param name="baseMethod">Method to create a unit test</param>
        /// <returns>Returns the response from OpenAI given the prompt for generating unit test</returns>
        Task<string> Generator(string progLang, string baseMethod, string frameWork);
    }
}
