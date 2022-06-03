using System.ComponentModel.DataAnnotations;

namespace Praksa_SecondProject.DTO
{
    public class AddBandDto
    {
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime Founded { get; set; }
        [Required]
        [MaxLength(100)]
        public string MainGenre { get; set; }
    }
}
