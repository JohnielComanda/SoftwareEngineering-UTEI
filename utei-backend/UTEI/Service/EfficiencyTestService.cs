using UTEI.Dtos;
using UTEI.GPTManager;
using UTEI.Models;

namespace UTEI.Service
{
    public class EfficiencyTestService : IEfficiencyTestService
    {
        private readonly IAnalyzer _analyzer;
        public EfficiencyTestService(IAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }

        public async Task<string> CreateTest(EfficiencyTestCreationDto testEfficiency)
        {
            throw new NotImplementedException();
        }

        public Task<EfficiencyTest> GetSavedTest(string id)
        {
            throw new NotImplementedException();
        }
    }
}
