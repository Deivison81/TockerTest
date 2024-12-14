using Microsoft.EntityFrameworkCore;
using TockerTest.API.Models;

namespace TockerTest.API.persistence
{
    public class TockenDbcontext : DbContext
    {
        public TockenDbcontext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoyDb");
        }

        public DbSet<User> Users {  get; set; }

    }
}
