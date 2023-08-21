using System.ComponentModel.DataAnnotations;

namespace CommandLine.Api.Models
{
    public class Command
    {
        public int Id { get; set; }

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
