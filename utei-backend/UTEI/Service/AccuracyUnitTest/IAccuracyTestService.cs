using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service.AccuracyUnitTest
{
    public interface IAccuracyTestService
    {
        Task<AccuracyTestModel> TestAccuracy(AccuracyTestDto accuInfo);
    }
}
