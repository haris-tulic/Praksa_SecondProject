using System.ComponentModel.DataAnnotations;

namespace Praksa_SecondProject.DTO
{
    public class AddAlbumDto
    {
       
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int BandId { get; set; }
    }
}
