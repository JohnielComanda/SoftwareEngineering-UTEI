using UTEI.Models;

namespace UTEI.Repository.AccuracyUnitTest
{
    public interface IAccuracyTestRepository
    {
        Task<string> CreateTest(AccuracyTestModel testAccuracy);
        Task<AccuracyTestModel> GetSavedTest(string id);
        Task<IEnumerable<AccuracyTestModel>> GetAllSavedTest();
    }
}
