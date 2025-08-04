using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TheToDoListApp.Repository.Models;

namespace TheToDoListApp.Repository.Domain
{
    public class ToDoListContextFactory : IDesignTimeDbContextFactory<ToDoListContext>
    {
        public ToDoListContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ToDoListContext>();
            optionsBuilder.UseSqlServer("Server=dESktoP-V8\\SQLEXPRESS;Database=TheTodoRazerApp;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLoggerFactory(new ServiceCollection()
            //              .AddLogging(builder => builder.AddConsole()
            //                                            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
            //               .BuildServiceProvider().GetService<ILoggerFactory>());

            return new ToDoListContext(optionsBuilder.Options);
        }
    }

    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
