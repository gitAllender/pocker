using System.ComponentModel.DataAnnotations;

namespace poker.Models
{
    public class LoginViewModel
    {   
        [Required]
        public string Name { get; set; }
    }
}