using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
{
    private readonly IDbConnection _dbConnection;
    protected override string TableName => "Order";

    public OrderRepository(IDbConnection dbConnection) : base(dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<List<Order>> GetUserOrders(int userId)
    {
        string sql = $@"
            SELECT
	            o.*
            FROM [{TableName}] o
            JOIN Employee e on e.Id = o.EmployeeId
            WHERE e.UserId = @UserId
            ORDER BY OrderDate DESC
        ";

        var orders = (await _dbConnection.QueryAsync<Order>(sql, new { UserId = userId })).ToList();
        return orders;
    }

    public async Task<dynamic> GetUserOrdersPreview(int userId)
    {
        string sql = $@"
            SELECT TOP 5
	            o.Id,
	            o.CustomerId,
	            o.OrderDate,
	            o.RequiredDate,
	            o.ShippedDate,
	            o.ShipCountry
            FROM [{TableName}] o
            JOIN Employee e on e.Id = o.EmployeeId
            WHERE e.UserId = @UserId
            ORDER BY OrderDate DESC
        ";

        var orders = (await _dbConnection.QueryAsync<dynamic>(sql, new { UserId = userId })).ToList();
        return orders;
    }

    public async Task<int> GetEmployeeId(int userId)
    {
        string sql = $@"SELECT Id from Employee WHERE UserId = @UserId";
        int employeeId = await _dbConnection.QueryFirstOrDefaultAsync<int>(sql, new { UserId = userId });
        return employeeId;
    }
}
