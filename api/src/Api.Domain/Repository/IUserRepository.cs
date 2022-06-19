using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByEmail(string email);
    }
}