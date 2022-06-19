using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Auth;
using Domain.Entities;
using Domain.Repository;

namespace Api.Service.Services.Auth
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _userRepository.FindByEmail(email);
        }
    }
}