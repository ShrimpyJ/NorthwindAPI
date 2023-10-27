using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

public class SupplierRepository : GenericRepository<Supplier, int>, ISupplierRepository
{
    private readonly IDbConnection _dbConnection;
    protected override string TableName => "Supplier";

    public SupplierRepository(IDbConnection dbConnection) : base(dbConnection)
    {
        _dbConnection = dbConnection;
    }
}
