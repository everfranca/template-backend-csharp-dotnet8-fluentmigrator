# Template: Migrations with FluentMigrator and PostgreSQL

## Descrição
Este é um projeto template para criação de projetos do tipo MigrationRunner utilizando FluentMigration e PostgreSQL (npgsql).
O projeto é totalmente interativo com o desenvolvedor no qual pode escolher o tipo de migração (Up ou Down) o ambiente, apenas visualização dos eventos e geração de scripts.

Caso queira alterar o banco de dados, instale o driver via nuget e altere o dialeto nas configurações.

## Tecnologias Utilizadas
- C#
- .NET 8
- FluentMigrator
- NpgSQL (PostgreSQL)

## Como Usar
 1. Clone o repositório:
	git clone https://github.com/everfranca/template-backend-csharp-dotnet8-fluentmigrator.git
2 . Restaure os pacotes
	dotnet restore
3. Execute o projeto:
	dotnet run 
4. Acesse a documentação do FluentMigrator em: 
https://fluentmigrator.github.io/
