using UTEI.Models;

namespace UTEI.Repository
{
    public class EfficiencyResultRepository : IEfficiencyResultRepository
    {
        public Task<TestEfficiencyResult> CreateTest(TestEfficiencyResult testEfficiency)
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

        public Task<IEnumerable<TestEfficiencyResult>> GetAllSavedTest()
        {
            throw new NotImplementedException();
        }

        public Task<TestEfficiencyResult> GetSavedTest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
