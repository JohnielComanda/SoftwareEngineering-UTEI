using UTEI.Models;

namespace UTEI.Repository.EnhanceUnitTest
{
    public interface IEfficiencyTestRepository
    {
        Task<string> CreateTest(EfficiencyTest testEfficiency);
        Task<EfficiencyTest> GetSavedTest(string id);
        Task<IEnumerable<EfficiencyTest>> GetAllSavedTest();
        Task<bool> DeleteAllTests();
        Task<bool> DeleteTestById(string id);
    }
}