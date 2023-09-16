using UTEI.Dtos;
using UTEI.GPTManager;
using UTEI.Models;
using UTEI.Repository;

namespace UTEI.Service
{
    public class EfficiencyTestService : IEfficiencyTestService
    {
        private readonly IAnalyzer _analyzer;
        private readonly IEfficiencyTestEnhancer _enhancer;
        private readonly IEfficiencyTestRepository _repository;
        public EfficiencyTestService(IAnalyzer analyzer, IEfficiencyTestEnhancer enhancer, IEfficiencyTestRepository efficiencyTestRepository)
        {
            _analyzer = analyzer;
            _enhancer = enhancer;
            _repository = efficiencyTestRepository;
        }

        public async Task<string> CreateTest(EfficiencyTestCreationDto testEfficiency)
        {
            var resultSummary = await _analyzer.Analyze(testEfficiency.UnitTest!);
            var efficiencyScore = await _analyzer.EvaluateTest(testEfficiency.UnitTest!);
            var testSuggestion = await _enhancer.SuggestionGenerator(testEfficiency.UnitTest!);
            var enhancedVersion = await _enhancer.Enhancer(testEfficiency.ProgrammingLanguage!, testEfficiency.UnitTest!);

            var efficiencyTest = new EfficiencyTest()
            {
                UnitTest = testEfficiency.UnitTest,
                ProgrammingLanguage = testEfficiency.ProgrammingLanguage,
                Date = DateTime.Today,
                ResultSummary = resultSummary.ToString(),
                EfficiencyScore = int.Parse(efficiencyScore),
                TestSuggestions = testSuggestion,
                EnhancedVersion = enhancedVersion
            };

            return await _repository.CreateTest(efficiencyTest);
        }

        public async Task<EfficiencyTest> GetSavedTest(string id)
        {
            return await _repository.GetSavedTest(id);
        }
    }
}
