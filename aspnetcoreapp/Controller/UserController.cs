using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("user/[controller]")]
[ApiController]
public class UserLoginController : ControllerBase 
{
    private readonly IUserRepository _userRepository;

    public UserLoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByUsernameAsync(loginRequest.UserName);
        if (user == null || !user.VerifyPassword(loginRequest.Password))
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }
        return Ok(new { message = "Login successful", user = user });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        var user = await _userRepository.GetUserByUsernameAsync(registerRequest.UserName);
        if (user != null)
        {
            return BadRequest(new { message = "Username already exists" });
        }
        user = new User
        {
            UserName = registerRequest.UserName
        };
        user.SetPassword(registerRequest.Password);
        await _userRepository.CreateUserAsync(user);
        return Ok(new { message = "User registered successfully", user = user });
    }
}
