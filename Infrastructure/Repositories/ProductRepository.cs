using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

public class ProductRepository : GenericRepository<Product, int>, IProductRepository
{
    private readonly IDbConnection _dbConnection;
    protected override string TableName => "Product";

    public ProductRepository(IDbConnection dbConnection) : base(dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<List<dynamic>> GetProductsAsync()
    {
        string sql = $@"
            SELECT
	            p.*,
	            s.CompanyName as SupplierName,
	            c.Name as CategoryName
            FROM [{TableName}] p
            JOIN Supplier s on s.Id = p.SupplierId
            JOIN Category c on c.Id = p.CategoryId   
        ";

        var products = (await _dbConnection.QueryAsync<dynamic>(sql)).ToList();
        return products;
    }

    public async Task<int> ReorderProductAsync(int id, int unitsToOrder)
    {
        string sql = $@"
            UPDATE [{TableName}]
            SET UnitsOnOrder = UnitsOnOrder + @UnitsToOrder
            WHERE Id = @Id
        ";
        return await _dbConnection.ExecuteAsync(sql, new { id, unitsToOrder });
    }
}
