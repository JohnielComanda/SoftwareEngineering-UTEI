using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service.EnhanceUnitTest
{
    public interface IEfficiencyTestService
    {
        Task<string> CreateTest(EfficiencyTestCreationDto testEfficiency);
        Task<EfficiencyTest> GetSavedTest(string id);
        Task<IEnumerable<EfficiencyTest>> GetAllSavedTest( );
    }
}
