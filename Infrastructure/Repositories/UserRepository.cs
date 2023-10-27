using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    private readonly IDbConnection _dbConnection;
    protected override string TableName => "User";

    public UserRepository(IDbConnection dbConnection, ILogger<UserRepository> logger) : base(dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<bool> CheckUsernameExistsAsync(string username)
    {
        string sql = $@"SELECT * FROM [{TableName}] WHERE lower(Username) = lower(@Username)";
        var result = await _dbConnection.QueryFirstOrDefaultAsync(sql, new { Username = username });
        if (result == null) return false;
        return true;
    }

    public async Task<int> LoginAsync(string username, byte[] password)
    {
        string sql = $@"SELECT Id FROM [{TableName}] WHERE Username = @Username AND Password = @Password";
        int userId = await _dbConnection.QueryFirstOrDefaultAsync<int>(sql, new { Username = username, Password = password });
        return userId;
    }
}
