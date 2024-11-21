using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Api.Infra.Repository;

public class BaseRepository(IConfiguration configuration)
{
    private readonly string _connectionString =
        configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException();

    public NpgsqlConnection GetConnection() => new(_connectionString);
}