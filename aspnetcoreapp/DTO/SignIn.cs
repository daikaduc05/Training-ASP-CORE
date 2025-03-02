using System.ComponentModel.DataAnnotations;

public class SignInModel
{
    [Required(ErrorMessage = "Username or Email is required")]
    public string UserNameOrEmail { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
