using UTEI.Dtos;
using UTEI.GPTManager.AccuracyUnitTest;
using UTEI.Models;

namespace UTEI.Service.AccuracyUnitTest
{
    public class AccuracyTestService : IAccuracyTestService
    {
        private readonly IAccuracyTest _accuTest;

        public AccuracyTestService(IAccuracyTest accuTest)
        {
            _accuTest = accuTest;
        }

        public async Task<AccuracyTestModel> TestAccuracy(AccuracyTestDto accuInfo)
        {
            AccuracyTestModel res = new AccuracyTestModel();
            res.TestResult = await _accuTest.TestCases(accuInfo);
            //res.EnhancedVersion = await _accuTest.Enhancer(accuInfo.ProgrammingLanguage, accuInfo.UnitTest);
            res.ResultSummary = await _accuTest.Summary(accuInfo.UnitTest);
            res.TestSuggestions = await _accuTest.Recommendations(accuInfo.UnitTest);
            //res.TestResult = "Pass";
            //res.EnhancedVersion = "Enhance Version";
            //res.ResultSummary = "Summary";
            //res.TestSuggestions = "Suggestion";
            return res;
        }
    }
}
