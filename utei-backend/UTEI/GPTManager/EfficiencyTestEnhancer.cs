using System.Text.Json;
using UTEI.Models;

namespace UTEI.GPTManager
{
    public class EfficiencyTestEnhancer : IEfficiencyTestEnhancer
    {
        public async Task<string> Enhancer(string progLang, string unitTest)
        {
            var requestPayload = new
            {
                prompt = $"Write an improved version of the following unit test method:\n\n```{progLang}\n{unitTest}\n```",
                temperature = 0.5,
                max_tokens = 256,
                top_p = 1.0,
                frequency_penalty = 0.0,
                presence_penalty = 0.0
            };

            using (var httpClient = new HttpClient())
            {
                // Set the OpenAI API endpoint and your API key
                var apiUrl = "https://api.openai.com/v1/engines/text-davinci-003/completions";
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

                try
                {
                    var response = await httpClient.PostAsJsonAsync(apiUrl, requestPayload);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadFromJsonAsync<OpenAIResponse>();

                        if (responseContent != null && responseContent.choices.Length > 0)
                        {
                            var improvedUnitTest = responseContent.choices[0].Trim();
                            Console.WriteLine("Huhuness");
                            return improvedUnitTest;
                        }
                        else
                        {
                            return "No response content or choices found.";
                        }
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return errorMessage;
                    }
                }
                catch (JsonException ex)
                {
                    return $"JSON deserialization error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }
            }
        }

        public Task<string> SuggestionGenerator()
        {
            throw new NotImplementedException();
        }
    }
}
