using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using System.Data;

public class CustomerRepository : GenericRepository<Customer, string>, ICustomerRepository
{
    private readonly IDbConnection _dbConnection;
    protected override string TableName => "Customer";

    public CustomerRepository(IDbConnection dbConnection) : base(dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<List<IdNamePair<string>>> GetIdNamePairsAsync()
    {
        string sql = $@"SELECT Id, Name FROM [{TableName}]";
        return (await DbConnection.QueryAsync<IdNamePair<string>>(sql)).ToList();
    }
}
