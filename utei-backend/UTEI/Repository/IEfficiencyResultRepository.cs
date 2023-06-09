﻿using UTEI.Models;

namespace UTEI.Repository
{
    public interface IEfficiencyResultRepository
    {
        Task<TestEfficiencyResult> CreateTest(TestEfficiencyResult testEfficiency);
        Task<TestEfficiencyResult> GetSavedTest(int id);
        Task<IEnumerable<TestEfficiencyResult>> GetAllSavedTest();
        Task<bool> DeleteAllTests();
        Task<bool> DeleteTestById(int id);
    }
}