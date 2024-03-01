using System.ComponentModel.DataAnnotations;

namespace UTEI.Dtos
{
    /// <summary>
    /// This dto is for the necessary inputs for generate test  
    /// </summary>
    public class GenerateTestCreationDto
    {
        [Required(ErrorMessage = "UserId is required.")]
        public string? UserId { get; set; }
        [Required(ErrorMessage = "UnitTest method is required.")]
        public string? BaseMethod { get; set; }
        [Required(ErrorMessage = "Programming language used in Unit Test method is required.")]
        public string? ProgrammingLanguage { get; set; }
        public string? Framework { get; set; }
    }
}
