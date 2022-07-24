using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Test.Helpers;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Xunit;

namespace Api.Data.Test.Implementations
{
    public class UserImplementationTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserImplementationTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        public async Task Deve_Ser_Possivel_Buscar_Usuario_Por_Email()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation repositorio = new UserImplementation(context);
                UserEntity entidade = UserImplementationHelper.ObterUmUsuarioValido();
                
                await repositorio.InsertAsync(entidade);
                
                var registroProcurado = await repositorio.FindByEmail(entidade.Email);
                
                Assert.NotNull(registroProcurado);
                Assert.Equal(registroProcurado.Id , entidade.Id);
                Assert.Equal(registroProcurado.Email , entidade.Email);
                Assert.Equal(registroProcurado.Name , entidade.Name);
                Assert.Null(registroProcurado.UpdateAt);
            }
        }
    }
}