using Praksa_SecondProject.Validate;
using System.ComponentModel.DataAnnotations;

namespace Praksa_SecondProject.DTO
{
    [AlbumValidation]
    public class AddAlbumDto/*:IValidatableObject*/
    {
       
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int BandId { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title==Description)
        //    {
        //        yield return new ValidationResult("Title and Description can't be the same!");
        //    }
        //}
    }
}
