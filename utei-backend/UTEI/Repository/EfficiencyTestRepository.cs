using UTEI.Models;

namespace UTEI.Repository
{
    public class EfficiencyTestRepository : IEfficiencyTestRepository
    {
        public Task<EfficiencyTest> CreateTest(EfficiencyTest testEfficiency)
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

        public Task<IEnumerable<EfficiencyTest>> GetAllSavedTest()
        {
            throw new NotImplementedException();
        }

        public Task<EfficiencyTest> GetSavedTest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
