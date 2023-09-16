using System.ComponentModel.DataAnnotations;

namespace UTEI.Dtos
{
    public class EfficiencyTestCreationDto
    {
        [Required(ErrorMessage = "UnitTest method is required.")]
        public string? UnitTest { get; set; }
        [Required(ErrorMessage = "Programming language used in Unit Test method is required.")]
        public string? ProgrammingLanguage { get; set; }
    }
}
