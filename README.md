# dotNET-Temporal

## O que é?

Projeto de estudo sobre implementações do SQL Temporal Table.

## Getting started

Para iniciar o projeto, altere a connection string com base no seu SQL Server, deve ficar assim: 

```
  Data Source="Servidor";Initial Catalog="Nome da Tabela";User Id="Usuario";Password="Senha";Encrypt=False
```

Depois, rode o comando para executar a migration no seu banco de dados: 

```
  dotnet ef update database
```
