using System.ComponentModel.DataAnnotations;

namespace SPA.DocumentManager.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}