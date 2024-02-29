using UTEI.Dtos;
using UTEI.GPTManager.GenerateUnitTest;
using UTEI.Models;
using UTEI.Repository.GenerateUnitTest;

namespace UTEI.Service.GenerateUnitTest
{
    public class GenerateTestService : IGenerateTestService
    {
        private readonly IGenerateTestRepository _repository;
        private readonly IUnitTestGenerator _unitTestGenerator;
        public GenerateTestService(IGenerateTestRepository repository, IUnitTestGenerator unitTestGenerator)
        {
            _repository = repository;
            _unitTestGenerator = unitTestGenerator;
        }

        /// <summary>
        /// This is for calling a test using a method from GPTManager classes and mapping the result to EfficiencyTest model
        /// </summary>
        /// <param name="generateTest">Necessary parameters for generate test</param>
        /// <returns>Returns the generate test result id</returns>
        public async Task<string> CreateTest(GenerateTestCreationDto generateTest)
        {
            var unitTestResult = await _unitTestGenerator.Generator(generateTest.ProgrammingLanguage!, generateTest.BaseMethod!, generateTest.Framework!);

            var generateUnitTest = new GenerateTest()
            {
                UserId = generateTest.UserId,
                BaseMethod = generateTest.BaseMethod,
                ProgrammingLanguage = generateTest.ProgrammingLanguage,
                Date = DateTime.Today,
                UnitTest = unitTestResult,
                Framework =  generateTest.Framework,
            };

            return await _repository.CreateTest(generateUnitTest);
        }

        /// <summary>
        /// This is for getting all the saved generate test
        /// </summary>
        /// <param name="id">Id of the currently logged in user</param>
        /// <returns>Returns all the tests that was done by the specific user</returns>
        public async Task<IEnumerable<GenerateTest>> GetAllSavedTest(string id)
        {
            var allTests = await _repository.GetAllSavedTest();
            var testsWithSameUserId = allTests.Where(test => test.UserId == id);
            return testsWithSameUserId;
        }

        /// <summary>
        /// This is for getting a saved test given by it's id
        /// </summary>
        /// <param name="id">Id of the test to retrieve</param>
        /// <returns>Returns the result of the test being retrieved</returns>
        public async Task<GenerateTest> GetSavedTest(string id)
        {
            return await _repository.GetSavedTest(id);
        }
    }
}
