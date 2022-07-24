using Domain.Entities;

namespace Api.Data.Test.Helpers
{
    public class UserImplementationHelper
    {
        public static UserEntity ObterUmUsuarioValido()
        {
            return new UserEntity
            {
                Name = Faker.NameFaker.FemaleName(),
                Email = Faker.InternetFaker.Email()
            };
        }
    }
}