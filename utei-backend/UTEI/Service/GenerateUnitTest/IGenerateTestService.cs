using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service.GenerateUnitTest
{
    public interface IGenerateTestService
    {
        /// <summary>
        /// This is for calling a test using a method from GPTManager classes
        /// </summary>
        /// <param name="generateTest">Necessary parameters for generate test</param>
        /// <returns>Returns the generate test result</returns>
        Task<string> CreateTest(GenerateTestCreationDto generateTest);

        /// <summary>
        /// This is for getting a saved test given by it's id
        /// </summary>
        /// <param name="id">Id of the test to retrieve</param>
        /// <returns>Returns the result of the test being retrieved</returns>
        Task<GenerateTest> GetSavedTest(string id);

        /// <summary>
        /// This is for getting all the saved generate test
        /// </summary>
        /// <param name="id">Id of the currently logged in user</param>
        /// <returns>Returns all the tests that was done by the specific user</returns>
        Task<IEnumerable<GenerateTest>> GetAllSavedTest(string id);
    }
}
