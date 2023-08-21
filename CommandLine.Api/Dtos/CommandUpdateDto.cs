using System.ComponentModel.DataAnnotations;

namespace CommandLine.Api.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(250)]
        public string Platform { get; set; }

        [Required]
        [MaxLength(250)]
        public string CommandLine { get; set; }
    }
}
