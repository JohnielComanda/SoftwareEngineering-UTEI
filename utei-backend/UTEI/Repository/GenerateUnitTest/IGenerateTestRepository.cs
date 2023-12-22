using UTEI.Models;

namespace UTEI.Repository.GenerateUnitTest
{
    public interface IGenerateTestRepository
    {
        /// <summary>
        /// This is for creation of generate test
        /// </summary>
        /// <param name="generateTest"></param>
        /// <returns>Returns the id of generate test result</returns>
        Task<string> CreateTest(GenerateTest generateTest);

        /// <summary>
        /// This is for getting a generate test result given an id of the test
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the previously done generate test result</returns>
        Task<GenerateTest> GetSavedTest(string id);

        /// <summary>
        /// This is for getting all generate test result from the database
        /// </summary>
        /// <returns>Returns all previously done generate test result</returns>
        Task<IEnumerable<GenerateTest>> GetAllSavedTest();

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAllTests();

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteTestById(string id);
    }
}
