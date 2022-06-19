using System.Threading.Tasks;
using Domain.Entities;

namespace Api.Domain.Interfaces.Services.Auth
{
    public interface ILoginService
    {
        Task<object> FindByEmail(string email);
    }
}