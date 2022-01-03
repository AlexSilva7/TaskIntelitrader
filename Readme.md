# Comando para rodar o programa
docker-compose up --build


# Eu, como usuário, desejo efetuar meu cadastro

Este ticket tem como objetivo criar uma API que permita o usuário fazer seu cadastro no sistema.

# Especificação
A entidade deve conter os seguintes campos: id (string), firstName (string), surname (string), age (int), creationDate (DateTime).

Todos os campos são obrigatórios, exceto o campo surname.

O campo id não deve ser inserido pelo usuário, mas gerado pelo sistema.

O campo creationDate não deve ser inserido pelo usuário, mas preenchido pelo sistema.

# Requisitos técnicos
Aplicação deve ser desenvolvida em ASP.NET Core MVC;

Dados devem ser persistidos para um banco de dados utilizando Entity Framework (EF Core);

Aplicação e banco de dados devem rodar dentro de contêineres Docker com imagem Linux (utilizar docker-compose para subir o ambiente).

Registra as operações (criação, deleção, edição etc) em log

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-5.0

Testes unitários

https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test

Requisitos técnicos:
Consultar usuários:

=========================================================
GET /Users

Resposta:

[
{ name: 'Cliente 1', surname: 'Sobrenome', age: 25, creationDate: '2020-12-01T01:00:00, id: 'b4f5a-b4f5a-b4f5a-b4f5a-b4f5a' ' },
{ name: 'Cliente 2', surname: 'Sobrenome 2', age: 25, creationDate: '2020-12-01T01:00:00, id: 'b4f5a-b4f5a-b4f5a-b4f5a-b4f5a' ' },
{ name: 'Cliente 3', surname: 'Sobrenome 3', age: 25, creationDate: '2020-12-01T01:00:00, id: 'b4f5a-b4f5a-b4f5a-b4f5a-b4f5a' ' }
]

=========================================================

PUT /Users/{id}

Request:

{
name: 'Novo nome',
surname: 'novo sobrenome',
age: 26
}
DELETE /Users/{id}

=========================================================

POST /Users
Request:

{
name: 'Nome',
surname : 'sobrenome',
age: 25
}