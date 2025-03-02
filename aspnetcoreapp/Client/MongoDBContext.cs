﻿using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

public class MongoDBContext
{
	private readonly IMongoDatabase _database;

	public MongoDBContext(IConfiguration configuration)
	{
		var connectionString = configuration["MongoDB:ConnectionString"];
		var databaseName = configuration["MongoDB:DatabaseName"];

		var client = new MongoClient(connectionString);
		_database = client.GetDatabase(databaseName);
	}

	public IMongoCollection<User> Users => _database.GetCollection<User>("users");
}
