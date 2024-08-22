using Microsoft.EntityFrameworkCore;
using TaskTrackr.Domain.Entities;

namespace TaskTrackr.Infrastructure.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItems");
        }
    }
}
