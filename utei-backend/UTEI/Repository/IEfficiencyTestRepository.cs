using UTEI.Models;

namespace UTEI.Repository
{
    public interface IEfficiencyTestRepository
    {
        Task<EfficiencyTestResult> CreateTest(EfficiencyTestResult testEfficiency);
        Task<EfficiencyTestResult> GetSavedTest(int id);
        Task<IEnumerable<EfficiencyTestResult>> GetAllSavedTest();
        Task<bool> DeleteAllTests();
        Task<bool> DeleteTestById(int id);
    }
}