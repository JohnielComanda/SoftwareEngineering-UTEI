﻿using System.Text.Json;
using UTEI.Models.OpenAIModel;

namespace UTEI.GPTManager
{
    public static class GPTRequestHandler
    {
        public static async Task<string> RequestHandler(string prompt, IHttpClientFactory httpClientFactory)
        {
            IHttpClientFactory _httpClientFactory = httpClientFactory;

            var requestPayload = new
            {
                prompt = prompt,
                temperature = 0.5,
                max_tokens = 256,
                top_p = 1.0,
                frequency_penalty = 0.0,
                presence_penalty = 0.0
            };

            using (var httpClient = new HttpClient())
            {
                //string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

                //// Check if the API key is not null or empty
                //if (string.IsNullOrEmpty(apiKey))
                //{
                //    Console.WriteLine("API key not found in environment variable OPENAI_API_KEY.");
                //    //return;
                //}

                var apiUrl = "https://api.openai.com/v1/engines/text-davinci-003/completions";
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

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
