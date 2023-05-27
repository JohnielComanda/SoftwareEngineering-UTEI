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
            var temp = await _analyzer.Analyze(testEfficiency.ProgrammingLanguage, testEfficiency.UnitTest);
            Console.WriteLine(temp);
            return temp;
        }

        public Task<EfficiencyTest> GetSavedTest(string id)
        {
            throw new NotImplementedException();
        }
    }
}
