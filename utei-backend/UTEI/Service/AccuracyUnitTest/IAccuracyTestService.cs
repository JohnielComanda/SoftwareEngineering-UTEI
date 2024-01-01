using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service.AccuracyUnitTest
{
    public interface IAccuracyTestService
    {
        Task<string> TestAccuracy(AccuracyTestDto accuInfo);
        Task<AccuracyTestModel> GetSavedTest(string id);
        Task<IEnumerable<AccuracyTestModel>> GetAllSavedTest(string id);
    }
}
