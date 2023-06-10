namespace Raziel.Database;

public enum SqlType
{
    SQLite
}

public static class DatabaseFactory
{
    public static DatabaseContext GetDatabase(SqlType sqlType)
    {
        return sqlType switch
        {
            SqlType.SQLite => CreateSQLiteDbContext(sqlType),
            _ => throw new NotImplementedException(),
        };
    }


    public static DatabaseContext CreateSQLiteDbContext(SqlType sqlType)
    {
        string connectionString = InjectJsonCredentials.Sql(sqlType);
        var context = new DatabaseContext($"Data Source={connectionString}", sqlType);
        return context;
    }

}
