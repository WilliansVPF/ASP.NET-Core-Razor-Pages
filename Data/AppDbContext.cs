using Microsoft.EntityFrameworkCore;
using TWTodoList.EntityConfig;
using TWTodoList.Models;

namespace TWTodoList.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=TWTodoList;User Id=sa;Password=Root@1234;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration<Todo>(new TodoEntityConfig());
    }
}