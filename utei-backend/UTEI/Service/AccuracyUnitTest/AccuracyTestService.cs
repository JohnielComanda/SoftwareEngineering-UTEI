using UTEI.Dtos;
using UTEI.GPTManager.AccuracyUnitTest;
using UTEI.Models;
using UTEI.Repository.AccuracyUnitTest;

namespace UTEI.Service.AccuracyUnitTest
{
    public class AccuracyTestService : IAccuracyTestService
    {
        private readonly IAccuracyTest _accuTest;
        private readonly IAccuracyTestRepository _accuTestRepo;

        public AccuracyTestService(IAccuracyTest accuTest, IAccuracyTestRepository accuTestRepo)
        {
            _accuTest = accuTest;
            _accuTestRepo = accuTestRepo;
        }

        public async Task<IEnumerable<AccuracyTestModel>> GetAllSavedTest(string id)
        {
<<<<<<< HEAD
            AccuracyTestModel res = new AccuracyTestModel();
            res.TestResult = await _accuTest.TestCases(accuInfo);
            //res.EnhancedVersion = await _accuTest.Enhancer(accuInfo.ProgrammingLanguage, accuInfo.UnitTest);
            res.ResultSummary = await _accuTest.Summary(accuInfo.UnitTest);
            //res.TestSuggestions = await _accuTest.Recommendations(accuInfo.UnitTest);
            //res.TestResult = "Pass";
            //res.EnhancedVersion = "Enhance Version";
            //res.ResultSummary = "Summary";
            //res.TestSuggestions = "Suggestion";
            return res;
=======
            var allTests = await _accuTestRepo.GetAllSavedTest();
            var testsWithSameUserId = allTests.Where(test => test.UserId == id);
            return testsWithSameUserId;
        }

        public async Task<AccuracyTestModel> GetSavedTest(string id)
        {
            return await _accuTestRepo.GetSavedTest(id);
        }

        public async Task<string> TestAccuracy(AccuracyTestDto accuInfo)
        {
            var testResult = await _accuTest.TestCases(accuInfo);
            var resultSummary = await _accuTest.Summary(accuInfo.UnitTest!);

            var accuracyTest = new AccuracyTestModel()
            {
                UserId = accuInfo.UserId,
                UnitTest = accuInfo.UnitTest,
                BaseMethod = accuInfo.BaseMethod,
                ProgrammingLanguage = accuInfo.ProgrammingLanguage,
                Date = DateTime.Today,
                ResultSummary = resultSummary,
                TestResult = testResult,
                TestSuggestions = "Suggestions",
                EnhancedVersion = "Enhance Version",
            };

            return await _accuTestRepo.CreateTest(accuracyTest);

            //AccuracyTestModel res = new AccuracyTestModel();
            //res.TestResult = await _accuTest.TestCases(accuInfo);
            ////res.EnhancedVersion = await _accuTest.Enhancer(accuInfo.ProgrammingLanguage, accuInfo.UnitTest);
            //res.ResultSummary = await _accuTest.Summary(accuInfo.UnitTest);
            //res.TestSuggestions = await _accuTest.Recommendations(accuInfo.UnitTest);
            ////res.TestResult = "Pass";
            ////res.EnhancedVersion = "Enhance Version";
            ////res.ResultSummary = "Summary";
            ////res.TestSuggestions = "Suggestion";
            //return res;
>>>>>>> 41b168642f05c61d99b676bea017ff8e5dba166b
        }
    }
}
