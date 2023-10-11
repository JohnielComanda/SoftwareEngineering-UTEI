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
        public async Task<string> CreateTest(GenerateTestCreationDto generateTest)
        {
            var unitTestResult = await _unitTestGenerator.Generator(generateTest.ProgrammingLanguage!, generateTest.BaseMethod!);

            var generateUnitTest = new GenerateTest()
            {
                BaseMethod = generateTest.BaseMethod,
                ProgrammingLanguage = generateTest.ProgrammingLanguage,
                Date = DateTime.Today,
                UnitTest = unitTestResult,
            };

            return await _repository.CreateTest(generateUnitTest);
        }

        public async Task<IEnumerable<GenerateTest>> GetAllSavedTest()
        {
            return await _repository.GetAllSavedTest();
        }

        public async Task<GenerateTest> GetSavedTest(string id)
        {
            return await _repository.GetSavedTest(id);
        }
    }
}
