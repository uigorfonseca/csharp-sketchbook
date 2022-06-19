using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}