using System.ComponentModel.DataAnnotations;

namespace UTEI.Dtos
{
    public class GenerateTestCreationDto
    {
        [Required(ErrorMessage = "UnitTest method is required.")]
        public string? BaseMethod { get; set; }
        [Required(ErrorMessage = "Programming language used in Unit Test method is required.")]
        public string? ProgrammingLanguage { get; set; }
    }
}
