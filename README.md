# Gerenciador de Produtos - Bootcamp C# Squadra

Esta API possibilita a cria��o, altera��o, exibi��o e remo��o de Produtos via HTTP. Tamb�m foi incluida de forma complementar a entidade de Usuarios para autentica��o em rotas privadas.

## Configura��o
- Altere o AppDbContext.cs com a string de conex�o do SQLServer(Esse projeto utilizou MSSQL LocalDb Express criado no pr�prio Visual Studio)
- Execute os seguintes comandos para preparar as tabelas no banco de dados
```sh
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef database update
```
- Execute a aplica��o.

## JSON Exemplo para cria��o inicial de dados.

Usuarios:
```json
{
	{
		"nome": "Jo�o",
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
		"nome": "Jos�",
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
		"nome": "Fog�o Brastemp",
		"descricao": "Fog�o 4 bocas",
		"status": "Indisponivel",
		"preco": 200,
		"quantidadeEstoque": 0
	},
}
```