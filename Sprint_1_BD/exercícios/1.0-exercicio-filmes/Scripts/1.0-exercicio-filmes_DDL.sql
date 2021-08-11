--Criar um banco de dados
Create Database CATALOGO;
Go

--Define o banco de dados que será utilizado
Use CATALOGO;
Go

--Criar uma tabela
Create Table Genero(
	idGenero Tinyint Primary Key identity(1,1),
	Nome_genero Varchar(20),
);
Go

--Excluir uma coluna da tabela Genero
--Alter Table Genero
--Drop Column Nome_genero

--Adicionar uma coluna na Tabela Genero
Alter Table Genero
Add Nome_genero Varchar(20) not null

Create Table Filme(
	idFilme Smallint Primary key identity(1,1),
	idGenero Tinyint Foreign Key references Genero(idGenero),
	Nome_filme Varchar(50) not null
);
Go
