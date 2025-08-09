using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWTodoList.Models;

namespace TWTodoList.EntityConfig;

public class TodoEntityConfig : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todo");

        builder.Property(todo => todo.Id)
            .HasColumnName("id");
        builder.HasKey(todo => todo.Id);

        builder.Property(todo => todo.Title)
            .HasColumnName("title")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(todo => todo.Date)
            .HasColumnName("date")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(todo => todo.IsCompleted)
            .HasColumnName("is_completed")
            .HasColumnType("bit")
            .IsRequired();
    }
}