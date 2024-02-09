using System.Text.Json;
using UTEI.Models.OpenAIModel;

namespace UTEI.GPTManager
{
    public static class GPTRequestHandler
    {
        /// <summary>
        /// This is for setting up the handler for the communication to OpenAI API
        /// </summary>
        /// <param name="prompt">Prompt that will be sent to the OpenAI API</param>
        /// <param name="httpClientFactory">Client for sending http request</param>
        /// <returns>Returns the response coming from OpenAI</returns>
        public static async Task<string> RequestHandler(string prompt, IHttpClientFactory httpClientFactory)
        {
            IHttpClientFactory _httpClientFactory = httpClientFactory;

            var requestPayload = new
            {
                prompt = prompt,
                temperature = 0.25,
                max_tokens = 2048,
                top_p = 1.0,
                frequency_penalty = 0.0,
                presence_penalty = 0.0
            };

            using (var httpClient = new HttpClient())
            {
                var openAIApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
                var apiUrl = "https://api.openai.com/v1/chat/completions";
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAIApiKey}");

                try
                {
                    var response = await httpClient.PostAsJsonAsync(apiUrl, requestPayload);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadFromJsonAsync<OpenAIResponse>();

                        if (responseContent != null && responseContent.choices!.Length > 0)
                        {
                            var improvedUnitTest = responseContent.choices[0].text!.Trim();
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
    }
}