﻿using System.Text.Json;
using UTEI.Models;

namespace UTEI.GPTManager
{
    public class EfficiencyTestEnhancer : IEfficiencyTestEnhancer
    {
        public async Task<string> Enhancer(string progLang, string unitTest)
        {
            var prompt = $"Write an improved version of the following unit test method:\n\n```{progLang}\n{unitTest}\n```";
            return await GPTRequestHandler.RequestHandler(prompt);
        }

        public Task<string> SuggestionGenerator()
        {
            throw new NotImplementedException();
        }
    }
}
