using UTEI.Models;

namespace UTEI.GPTManager
{
    public class Analyzer : IAnalyzer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Analyzer(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<string> Analyze(string progLang, string unitTest)
        {
            var requestPayload = new
            {
                prompt = $"Write an improved version of the following unit test method:\n\n```{progLang}\n{unitTest}\n```",
                max_tokens = 100,
                temperature = 0.7,
                n = 1,
                stop = "\n"
            };

            var httpClient = _httpClientFactory.CreateClient();

            // Set the OpenAI API endpoint and your API key
            var apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_API_KEY");

            var response = await httpClient.PostAsJsonAsync(apiUrl, requestPayload);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadFromJsonAsync<OpenAIResponse>();

                var improvedUnitTest = responseContent?.choices[0].Trim();

                return improvedUnitTest!;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return errorMessage;
            }
        }

        public Task<string> EvaluateTest(string input)
        {
            throw new NotImplementedException();
        }
    }
}
