using Praksa_SecondProject.DTO;
using System.ComponentModel.DataAnnotations;

namespace Praksa_SecondProject.Validate
{
    public class AlbumValidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var album = (AddAlbumDto)validationContext.ObjectInstance;// dohvatanje objekta
            if (album.Title==album.Description)
            {
                return new ValidationResult("Title and Description can't be the same!");
            }
            return  ValidationResult.Success;
        }
    }
}
