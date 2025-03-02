using MongoDB.Driver;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(MongoDBContext dbContext)
    {
        _users = dbContext.Users;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _users.Find(u => u.UserName == username).FirstOrDefaultAsync();
    }

    public async Task CreateUserAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }
}
