namespace UTEI.Models.OpenAIModel
{
    public class OpenAIChoice
    {
        public OpenAIMessage? message { get; set; }
        public string? text { get; set; }
    }

    public class OpenAIMessage
    {
        public string? content { get; set; }
        public string? role { get; set; }
    }
}
