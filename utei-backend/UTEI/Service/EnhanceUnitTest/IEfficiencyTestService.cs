using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service.EnhanceUnitTest
{
    public interface IEfficiencyTestService
    {
        /// <summary>
        /// This is for calling a test using a method from GPTManager classes and mapping the result to EfficiencyTest model
        /// </summary>
        /// <param name="testEfficiency">Necessary parameters for efficiency test</param>
        /// <returns>Returns the id of the newly created test</returns>
        Task<string> CreateTest(EfficiencyTestCreationDto testEfficiency);

        /// <summary>
        /// This is for getting a saved test given by it's id
        /// </summary>
        /// <param name="id">Id of the saved test to be retrieved</param>
        /// <returns>Returns saved efficiency test result</returns>
        Task<EfficiencyTest> GetSavedTest(string id);

        /// <summary>
        /// This is for getting all the saved test that is done by a specific user
        /// </summary>
        /// <param name="id">Id of the currently logged in user</param>
        /// <returns>Returns all the saved efficiency test</returns>
        Task<IEnumerable<EfficiencyTest>> GetAllSavedTest(string id);
    }
}
