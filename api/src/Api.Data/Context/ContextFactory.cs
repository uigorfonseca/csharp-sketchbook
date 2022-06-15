using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var conectionString = "Server=localhost;Port=3306;Database=api;Uid=root;Pwd=secret";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseMySql(conectionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
