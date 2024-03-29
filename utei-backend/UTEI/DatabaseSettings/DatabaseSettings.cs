﻿namespace UTEI.DatabaseSetting
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? UsersCollectionName { get; set; }
        public string? EfficiencyTestsCollectionName { get; set; } 
        public string? GenerateTestsCollectionName { get; set; }
        public string? AccuracyTestsCollectionName { get; set; }
    }
}
