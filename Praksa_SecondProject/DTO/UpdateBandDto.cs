using System.ComponentModel.DataAnnotations;

namespace Praksa_SecondProject.DTO
{
    public class UpdateBandDto
    {
        [Required]
        public int Id { get; set; }
        
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
