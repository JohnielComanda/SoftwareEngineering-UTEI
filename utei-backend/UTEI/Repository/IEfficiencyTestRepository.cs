using UTEI.Models;

namespace UTEI.Repository
{
    public interface IEfficiencyTestRepository
    {
        Task<EfficiencyTest> CreateTest(EfficiencyTest testEfficiency);
        Task<EfficiencyTest> GetSavedTest(int id);
        Task<IEnumerable<EfficiencyTest>> GetAllSavedTest();
        Task<bool> DeleteAllTests();
        Task<bool> DeleteTestById(int id);
    }
}