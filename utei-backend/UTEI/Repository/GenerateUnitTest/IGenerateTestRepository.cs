using UTEI.Models;

namespace UTEI.Repository.GenerateUnitTest
{
    public interface IGenerateTestRepository
    {
        Task<string> CreateTest(GenerateTest generateTest);
        Task<GenerateTest> GetSavedTest(string id);
        Task<IEnumerable<GenerateTest>> GetAllSavedTest();
        Task<bool> DeleteAllTests();
        Task<bool> DeleteTestById(string id);
    }
}
