using System.Threading.Tasks;

public interface IAuthService
{
    Task<bool> SignInAsync(string usernameOrEmail, string password);
}
