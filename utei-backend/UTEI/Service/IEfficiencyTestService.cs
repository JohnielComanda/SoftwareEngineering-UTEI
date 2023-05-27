using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service
{
    public interface IEfficiencyTestService
    {
        Task<string> CreateTest(EfficiencyTestCreationDto testEfficiency);
        Task<EfficiencyTest> GetSavedTest(string id);
    }
}
