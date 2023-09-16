using UTEI.Models;

namespace UTEI.Repository
{
    public interface IEfficiencyTestRepository
    {
        Task<string> CreateTest(EfficiencyTest testEfficiency);
        Task<EfficiencyTest> GetSavedTest(string id);
        Task<IEnumerable<EfficiencyTest>> GetAllSavedTest();
        Task<bool> DeleteAllTests();
        Task<bool> DeleteTestById(int id);
    }
}