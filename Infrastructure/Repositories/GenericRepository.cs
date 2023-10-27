using Application.DTOs;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

public abstract class GenericRepository<TEntity, TId>
{
    protected IDbConnection DbConnection { get; }
    protected abstract string TableName { get; }

    public GenericRepository(IDbConnection dbConnection)
    {
        DbConnection = dbConnection;
    }

    public async Task<TId> AddAsync(TEntity entity)
    {
        var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "Id");
        var columns = string.Join(", ", properties.Select(p => p.Name));
        var values = string.Join(", ", properties.Select(p => "@" + p.Name));

        string sql = $@"
            INSERT INTO [{TableName}]
            ({columns})
            VALUES
            ({values})
            SELECT SCOPE_IDENTITY();";

        var id = await DbConnection.QuerySingleAsync<TId>(sql, entity);
        //typeof(TEntity).GetProperty("Id")?.SetValue(entity, id);
        return id;
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "Id");
        var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
        string sql = $@"
            UPDATE [{TableName}]
            SET 
                {setClause}
            WHERE Id = @Id";

        var affectedRows = await DbConnection.ExecuteAsync(sql, entity);
        return affectedRows;
    }

    public async Task<int> DeleteAsync(TId id)
    {
        string sql = $@"DELETE FROM [{TableName}] WHERE Id = @Id";
        return await DbConnection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        string sql = $@"SELECT * FROM [{TableName}] WHERE Id = @Id";
        var result = await DbConnection.QuerySingleOrDefaultAsync<TEntity>(sql, new { Id = id });
        return result;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        string sql = $@"SELECT * FROM [{TableName}]";
        return (await DbConnection.QueryAsync<TEntity>(sql)).ToList();
    }
}
