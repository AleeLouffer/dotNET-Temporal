# dotNET-Temporal

## Sobre

### O que é Temporal Table?

Segundo a Microsoft: 

"Tabelas temporais (também conhecidas como tabelas temporais com controle de versão do sistema) são um recurso de banco de dados com suporte interno para fornecer informações sobre dados armazenados na tabela em qualquer ponto no tempo em vez de apenas os dados que estão corretos no momento."

### Sobre o projeto

Este é um projeto simples, para demonstrar a funcionalidade na pratica de tabelas temporais do SQL Server, utilizando o Entity Framework como ORM, para cadastrar e obter dados do SQL Server.

Este projeto não viza nenhum tipo de lucro, é um projeto somente de estudo sobre a tecnologia.

## Getting started

### Linux, macOS, Windows (VSCode)
Para iniciar o projeto, altere a connection string com base no seu SQL Server, deve ficar assim: 

```json
	Data Source="Servidor";Initial Catalog="Nome da Tabela";User Id="Usuario";Password="Senha";Encrypt=False
```

Instale a CLI do Entity Framework Core com o seguinte comando no terminal:
```
	dotnet tool install -g dotnet-ef --version 9.0.11
```

Caso não exporte automaticamente a variavel de ambiente, exporte ela com o seguinte comando no Linux e macOS:
```
	export PATH="$PATH:/home/user/.dotnet/tools"
```

Depois, rode o comando para executar a migration no seu banco de dados: 

```
	dotnet ef database update
```

Após feita a migração, rode o projeto com:
```
	dotnet watch
```

Se a pagina com scalar não abrir automaticamente, abra a rota

```
	/scalar
```

### Windows (Visual Studio 2019+)

Para iniciar o projeto, sua connection string deve estar assim:

```json
	Data Source=localhost\SQLEXPRESS;Initial Catalog=TemporalTest;Integrated Security=SSPI;
```

Depois, abra o Package Manager e execute o comando:

```
	Update-Database
```

Se a pagina com scalar não abrir automaticamente, abra a rota

```
	/scalar
```

## Documentação da API

#### Insere um novo usuário.

```http
  POST /
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `Name` | `string` | **Obrigatório**. Nome do Usuario |
| `Login` | `string` | **Obrigatório**. Login do Usuario |
| `Password` | `string` | **Obrigatório**. Senha do Usuario |
| `Email` | `string` | **Obrigatório**. Email do Usuario |

#### Atualiza um usuario já cadastrado por ID.

```http
  PUT /${id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `Id` | `int` | **Obrigatório**. ID do Usuario Cadastrado |
| `Name` | `string` | **Obrigatório**. Nome do Usuario |
| `Login` | `string` | **Obrigatório**. Login do Usuario |
| `Password` | `string` | **Obrigatório**. Senha do Usuario |
| `Email` | `string` | **Obrigatório**. Email do Usuario |


#### Obtem histórico do usuario cadastrado.
```http
  GET /Changes/${id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `Id` | `int` | **Obrigatório**. ID do Usuario Cadastrado |




## Referência

 - [Microsoft Temporal Table](https://learn.microsoft.com/pt-br/sql/relational-databases/tables/temporal-tables?view=sql-server-ver17)


