using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseMySql("Persist Security Info=True; Server=localhost;Port=3306;Database=dbAluraFilmesTST;Uid=root;Pwd=mudar@123",
                new MySqlServerVersion(new Version(8,0,23)));
                
            return new MyContext(optionsBuilder.Options);
        }
    }
}