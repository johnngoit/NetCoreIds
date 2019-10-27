using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace Ids.Data
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=IDSDB1;Persist Security Info=True;User ID=cyberproduct;Password=x2000; Connect Timeout=600;Max Pool Size = 200;Pooling = True";
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}