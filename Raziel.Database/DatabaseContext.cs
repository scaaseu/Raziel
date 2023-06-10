using Microsoft.EntityFrameworkCore;
using Raziel.Database.Models;

namespace Raziel.Database;

public class DatabaseContext : DbContext 
{

    private bool _sqLite = false;
    private string _connection;
    
    public DatabaseContext(string connection, SqlType sqlType) {
        _connection = connection;
        switch (sqlType) {
             case SqlType.SQLite:    _sqLite    = true;  break;
         }
    }

    public DbSet<Secrets> Secrets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (_sqLite) optionsBuilder.UseSqlite(_connection);
    }


    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
    }

}