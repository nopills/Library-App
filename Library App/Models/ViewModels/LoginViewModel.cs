using System.ComponentModel.DataAnnotations;


namespace Library_App.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a Username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
