using System.Threading.Tasks;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> SignInAsync(string usernameOrEmail, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(usernameOrEmail);

        if (user == null || !user.VerifyPassword(password))
            return true;

        return false;
    }
}
