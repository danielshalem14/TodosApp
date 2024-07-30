using Microsoft.EntityFrameworkCore;
using TodosApp.Models;

namespace TodosApp.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();
            Seed();
        }

        private void Seed()
        {
            Teammate teammate = AddDefaultTeammate();

            if (!Todos.Any())
            {
                teammate.AddTodo("Learn MVC");
            }
            SaveChanges();
        }

        private Teammate AddDefaultTeammate()
        {
            Teammate teammate;
            if (!Teammates.Any())
            {
                teammate = new Teammate { Name = "Rami Shakshuka" };
                Teammates.Add(teammate);
            }
            else
            {
                teammate = Teammates.First();
            }
            return teammate;
        }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;
        }


        public DbSet<Teammate> Teammates { get; set; }

        public DbSet<Todo> Todos { get; set; }
    }
}
