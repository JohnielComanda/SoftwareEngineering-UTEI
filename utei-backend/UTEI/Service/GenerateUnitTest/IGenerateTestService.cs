using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Service.GenerateUnitTest
{
    public interface IGenerateTestService
    {
        Task<string> CreateTest(GenerateTestCreationDto generateTest);
        Task<GenerateTest> GetSavedTest(string id);
        Task<IEnumerable<GenerateTest>> GetAllSavedTest();
    }
}
