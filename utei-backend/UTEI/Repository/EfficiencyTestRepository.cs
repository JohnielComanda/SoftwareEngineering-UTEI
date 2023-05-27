using UTEI.Models;

namespace UTEI.Repository
{
    public class EfficiencyTestRepository : IEfficiencyTestRepository
    {
        public Task<EfficiencyTestResult> CreateTest(EfficiencyTestResult testEfficiency)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAllTests()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTestById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EfficiencyTestResult>> GetAllSavedTest()
        {
            throw new NotImplementedException();
        }

        public Task<EfficiencyTestResult> GetSavedTest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
