using System.ComponentModel.DataAnnotations;

namespace UTEI.Dtos
{
    public class AccuracyTestDto
    {
        [Required(ErrorMessage = "UnitTest method is required.")]
        public string? BaseMethod { get; set; }
        [Required(ErrorMessage = "Programming language used in Unit Test method is required.")]
        public string? ProgrammingLanguage { get; set; }
        [Required(ErrorMessage = "UnitTest is required.")]
        public string? UnitTest { get; set; }
        public string? UnitTestType { get; set; }
        public string? Description { get; set; }
        public string? Dependency1 { get; set; }
        public string? Dependency2 { get; set; }
    }
}
