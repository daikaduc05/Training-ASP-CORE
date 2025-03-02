using MongoDB.Driver;

public class MongoDBContext
{
	private readonly IMongoDatabase _database;

	public MongoDBContext()
	{
		var connectionString = configuration["MongoDB:ConnectionString"];
		var databaseName = configuration["MongoDB:DatabaseName"];

		var client = new MongoClient(connectionString);
		_database = client.GetDatabase(databaseName);
	}

	public IMongoCollection<User> Users => _database.GetCollection<User>("users");
	public IMongoCollection<Product> Products => _database.GetCollection<Product>("products");
	public IMongoCollection<Order> Orders => _database.GetCollection<Order>("orders");
}
