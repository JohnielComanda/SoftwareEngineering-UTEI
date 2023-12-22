using UTEI.Dtos;
using UTEI.GPTManager.EnhanceUnitTest;
using UTEI.Models;
using UTEI.Repository.EnhanceUnitTest;
using UTEI.Service.EnhanceUnitTest;

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

        /// <summary>
        /// This is for calling a test using a method from GPTManager classes and mapping the result to EfficiencyTest model
        /// </summary>
        /// <param name="testEfficiency">Necessary parameters for efficiency test</param>
        /// <returns>Returns the id of the newly created test</returns>
        public async Task<string> CreateTest(EfficiencyTestCreationDto testEfficiency)
        {
            var tempResponse = await _analyzer.Analyze(testEfficiency.UnitTest!);
            var resultSummarySuggestion = tempResponse.Split("$");
            var summary = resultSummarySuggestion[0];
            var suggestion = resultSummarySuggestion[1];
            var efficiencyScore = await _analyzer.EvaluateTest(testEfficiency.UnitTest!);
<<<<<<< HEAD
            var testSuggestionTemp = await _enhancer.SuggestionGenerator(testEfficiency.UnitTest!);
            //var enhancedVersion = await _enhancer.Enhancer(testEfficiency.ProgrammingLanguage!, testEfficiency.UnitTest!);
            var enhancedVersionTemp = testSuggestionTemp.Split("Improved Version:");
            var testSuggestion = enhancedVersionTemp[0];
            var enhancedVersion = enhancedVersionTemp[1];
=======
            var enhancedVersion = await _enhancer.Enhancer(testEfficiency.ProgrammingLanguage!, testEfficiency.UnitTest!);
>>>>>>> 41b168642f05c61d99b676bea017ff8e5dba166b

            var efficiencyTest = new EfficiencyTest()
            {
                UserId = testEfficiency.UserId,
                UnitTest = testEfficiency.UnitTest,
                ProgrammingLanguage = testEfficiency.ProgrammingLanguage,
                Date = DateTime.Today,
                ResultSummary = summary,
                EfficiencyScore = int.Parse(efficiencyScore),
                TestSuggestions = suggestion,
                EnhancedVersion = enhancedVersion
            };

            return await _repository.CreateTest(efficiencyTest);
        }

        /// <summary>
        /// This is for getting all the saved test that is done by a specific user
        /// </summary>
        /// <param name="id">Id of the currently logged in user</param>
        /// <returns>Returns all the saved efficiency test</returns>
        public async Task<IEnumerable<EfficiencyTest>> GetAllSavedTest(string id)
        {
            var allTests = await _repository.GetAllSavedTest();
            var testsWithSameUserId = allTests.Where(test => test.UserId == id);
            return testsWithSameUserId;
        }

        /// <summary>
        /// This is for getting a saved test given by it's id
        /// </summary>
        /// <param name="id">Id of the saved test to be retrieved</param>
        /// <returns>Returns saved efficiency test result</returns>
        public async Task<EfficiencyTest> GetSavedTest(string id)
        {
            return await _repository.GetSavedTest(id);
        }
    }
}
