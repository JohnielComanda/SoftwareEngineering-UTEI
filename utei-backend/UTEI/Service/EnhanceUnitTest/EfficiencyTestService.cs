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
            string summary = string.Empty;
            string suggestion = string.Empty;

            // Check if the response contains the delimiter '$'
            var delimiterIndex = tempResponse.IndexOf('$');
            if (delimiterIndex != -1)
            {
                // Split the response into summary and suggestion based on the delimiter
                summary = tempResponse.Substring(0, delimiterIndex);
                suggestion = tempResponse.Substring(delimiterIndex + 1);

                // Now you can use 'summary' and 'suggestion' separately
            }
            else
            {
                // Handle the case where the delimiter is not found in the response
                // This could indicate an unexpected format or error in the response
                // You may log a warning or handle it based on your application's logic
            }

            var efficiencyScore = await _analyzer.EvaluateTest(testEfficiency.UnitTest!);

            Console.WriteLine("Efficiency Score1: ", int.Parse(efficiencyScore));

            var enhancedVersion = await _enhancer.Enhancer(testEfficiency.ProgrammingLanguage!, testEfficiency.UnitTest!);
            Console.WriteLine("Efficiency Score2: ", int.Parse(efficiencyScore));

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
            Console.WriteLine("Efficiency Score3: ", (efficiencyTest.EfficiencyScore));
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
