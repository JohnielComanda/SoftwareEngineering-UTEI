using UTEI.Models;

namespace UTEI.Repository.EnhanceUnitTest
{
    public interface IEfficiencyTestRepository
    {
        /// <summary>
        /// This is for the creation of efficiency test
        /// </summary>
        /// <param name="testEfficiency"></param>
        /// <returns>Returns the id of efficiency test result</returns>
        Task<string> CreateTest(EfficiencyTest testEfficiency);

        /// <summary>
        /// This is for getting an efficiency test given the ID of the test
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a result of previously done efficiency test</returns>
        Task<EfficiencyTest> GetSavedTest(string id);

        /// <summary>
        /// This is for getting all efficiency test that is in database
        /// </summary>
        /// <returns>Returns a result of all the previously done efficiency test</returns>
        Task<IEnumerable<EfficiencyTest>> GetAllSavedTest();

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