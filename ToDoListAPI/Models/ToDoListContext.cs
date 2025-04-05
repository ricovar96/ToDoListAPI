using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Models
{
    public class ToDoListContext: DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
