# Gerenciador de Produtos - Bootcamp C# Squadra

Esta API possibilita a criação, alteração, exibição e remoção de Produtos via HTTP. Também foi incluida de forma complementar a entidade de Usuarios para autenticação em rotas privadas.

## Configuração
- Altere o AppDbContext.cs com a string de conexão do SQLServer(Esse projeto utilizou MSSQL LocalDb Express criado no próprio Visual Studio)
- Execute os seguintes comandos para preparar as tabelas no banco de dados
```sh
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef database update
```
- Execute a aplicação.

## JSON Exemplo para criação inicial de dados.

Usuarios:
```json
{
	{
		"nome": "João",
		"email": "joao@gmail.com",
		"userName": "joao",
		"password": "1234",
		"funcao": "Gerente"
	},
	{
		"nome": "Maria",
		"email": "maria@gmail.com",
		"userName": "maria",
		"password": "1234",
		"funcao": "Funcionario"
	},
	{
		"nome": "José",
		"email": "jose@gmail.com",
		"userName": "jose",
		"password": "1234",
		"funcao": "Funcionario"
	}
}
```
Produtos:
```json
{
	{
		"nome": "Computador Dell",
		"descricao": "Computador Dell i5",
		"status": "Em estoque",
		"preco": 100,
		"quantidadeEstoque": 50
	},
	{
		"nome": "Lavadora de Roupas",
		"descricao": "Lavadora Samsung",
		"status": "Em estoque",
		"preco": 300,
		"quantidadeEstoque": 10
	},
	{
		"nome": "Fogão Brastemp",
		"descricao": "Fogão 4 bocas",
		"status": "Indisponivel",
		"preco": 200,
		"quantidadeEstoque": 0
	},
}
```