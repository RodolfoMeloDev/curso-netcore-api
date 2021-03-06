using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=5432;Database=dbAPI;User Id=postgres;Password=admin;Timeout=15;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseNpgsql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}
