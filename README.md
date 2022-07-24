

# CSharp-sketchbook

![LiveMessage_2022-05-25-15-24-48](https://user-images.githubusercontent.com/40609362/171283452-3cbe3076-40c9-44b6-b63e-a2cdc1c21556.gif)

[![CodeFactor](https://www.codefactor.io/repository/github/uigormarshall/csharp-sketchbook/badge)](https://www.codefactor.io/repository/github/uigormarshall/csharp-sketchbook)

**Descrição**

Repositorio é utilizado para armazenar conceitos e ideias sobre c# e seu universo. Todas as soluções e projetos encontrados aqui são meramente provas de conceitos e rascunhos utilizados na aprendidazem dessa linguagem de progração e suas tecnologias derivadas.



**Projetos e Conteudos**

 - [ ] C# Básico
	 - [ ] Solution
	 - [ ] Namespace
	 - [ ] Classe
	 - [ ] Comentários
	 - [ ] Tipos Primitivos
	 - [ ] Declaração de variáveris
	 - [ ] Operadores Aritméticos
	 - [ ] Incremento e Decremento
	 - [ ] Operadores Lógicos
	 - [ ] Operadores Relacionais
	 - [ ] If/Else
	 - [ ] For
	 - [ ] While, Continue e Break
	 - [ ] Switch
 - [ ] API(aspnet core 3.1)
     - [x]  Criação da solução e camadas da arquitetura
	      - [x]  Solução
	      - [x]  Camada Application(webapi)
	      - [x]  Camadas de Infraestura
		      - [x]  Domain
		      - [x] Cross Cutting
		      - [x] Data
		      - [x] Service
     - [x] Camada Data
	     - [x] Base Entitity
	     - [x] User Entity
	     - [x] Instalaçao de pacotes ORM
	     - [x] Implementação do context
	     - [x] Referencia da camada Data com Domain
	     - [x] Implementar ContextFactory
	     - [x] Implementar UserMap
	     - [x] Implementar Migrations do User
	     - [x] Implementar interface de repositorio genérico
	     - [x] Implementar repositorio genérico
			- [x] InsertAsync
			- [x] UpdateAsync
			- [x] DeleteAsync
			- [x] ExistsAsync
			- [x] SelectAsync
	- [x] Camada Service
		- [x] Implementar interface UserService
		- [x] Criar referencias Data, CrossCutting e Domaon
		- [x] Implementar UserService
	- [ ]  Camada Application
		- [x] Adicionar Referencias e Criar a classe UsersController
		- [x] Implementar método GetAll
		- [x] Configurar injeção de dependência
		- [x] Implementar método Get por Id
		- [x] Implementar método Post para criação
		- [x]  Implementar método PUT para atualizar registros
		- [x]  Implementar método DELETE
		- [ ] Implementar Swagger
	- [x] 🔒 Validação via JWT
		- [x] Api.Data - Adicionar IUserRepository
		- [x] Api.Data - Adicionar UserImplementation
		- [x] Api.Domain - Adicionar ILoginService
		- [x] Api.Service - Implementar interface ILoginService
		- [x] Api.Application - Implementar LoginController
		- [x] Api.CrossCutting - Injeção de dependências
		- [x] Api.Domain - Criar Login DTO
		- [x] Api... - Substituir uso de Entidade(User) como input/output nas operações referentes ao Login
		- [x] Api.Domain - Implementar Classe SigningConfigurations e TokenConfigurations
		- [x] Api.Application - Adicionar Configuração do Token AppSerttings
		- [x] Api.Service - Implementar geração do Token
		- [x] Api.Application - Instalar lib Authentication.JwtBearer
		- [x] Api.Application - Implementar Uso do Token(Startup.cs)
	- [ ] 👩🏽‍🔬 Testes
		- [ ] Camada de Data
		- [ ] Camada de Service
	
