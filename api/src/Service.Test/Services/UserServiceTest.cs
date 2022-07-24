using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Domain.Entities;
using Domain.Repository;
using Moq;
using Xunit;

namespace Service.Test.Services
{
    public class UserServiceTest
    {
        private IUserService _service;
        private IUserRepository _repository;
        private Mock<IUserRepository> _mockRepository;
        [Fact]
        public async Task GetAll_Deve_Retornar_Uma_Lista_De_Usuarios_Validos()
        {
            IList<UserEntity> esperado = new List<UserEntity>();
            esperado.Add(new UserEntity
            {
                Id = new Guid(),
                Name = Faker.NameFaker.FemaleName(),
                Email = Faker.InternetFaker.Email(),
                CreatAt =   new DateTime(),
                UpdateAt = null
            });
            
            esperado.Add(new UserEntity
            {
                Id = new Guid(),
                Name = Faker.NameFaker.FemaleName(),
                Email = Faker.InternetFaker.Email(),
                CreatAt =   new DateTime(),
                UpdateAt = null
            });
            
            _mockRepository = new Mock<IUserRepository>();
            _mockRepository.Setup(m => m.SelectAsync()).ReturnsAsync(esperado);
            
            _service = new UserService(_mockRepository.Object);
            
            var resultado = await _service.GetAll();
            Assert.NotEmpty(resultado);
            Assert.Equal(esperado.Count, resultado.Count());
        }
        
        
        [Fact]
        public async Task Get_Dado_Um_Id_Existente_Deve_Retornar_Um_Usurio_Valido()
        {
            var esperado = new UserEntity
            {
                Id = new Guid(),
                Name = Faker.NameFaker.FemaleName(),
                Email = Faker.InternetFaker.Email(),
                CreatAt =   new DateTime(),
                UpdateAt = null
            };
            
            _mockRepository = new Mock<IUserRepository>();
            _mockRepository.Setup(m => m.SelectAsync(esperado.Id)).ReturnsAsync(esperado);
            
            _service = new UserService(_mockRepository.Object);
            
            var resultado = await _service.Get(esperado.Id);
            Assert.Equal(resultado.Id, esperado.Id);
        }
    }
}