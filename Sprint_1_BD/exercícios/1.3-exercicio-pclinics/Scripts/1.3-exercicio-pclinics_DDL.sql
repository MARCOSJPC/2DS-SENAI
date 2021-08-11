Create database PCLINICS;
GO

USE PCLINICS;
GO

Create Table Clinica(
idClinica tinyint primary key identity(1,1),
NomeClinica varchar(20) not null,
EndClinica varchar(100)not null
);
Go

Create Table Dono(
idDono int primary key identity(1,1),
NomeDono varchar(30) not null
);
Go

Create table TipoPet(
idTipoPet Smallint primary key identity(1,1),
TipoPet varchar(20) not null
);
Go

Create Table Raca(
idRaça Smallint primary key identity(1,1),
idTipoPet Smallint Foreign Key references Tipo_de_Pet(idTipoPet),
RacaPet varchar(30) not null
);
Go

Create Table Pets(
idPet int Primary key identity(1,1),
idDono int Foreign Key references Dono(idDono),
idRaca smallint Foreign Key references Raça(idRaça),
NomePet Varchar(20) Not null,
DataNasc Date not null
);
Go


Create Table Veterinario(
idVeterinario Smallint Primary key identity(1,1),
idClinica Tinyint Foreign Key references Clinica(idClinica),
NomeVet Varchar(30) not null,
CRMV char(8) not null
);
Go

Create Table Cadastro(
idCadastro Smallint Primary key identity(1,1),
idVeterinario Smallint Foreign Key references Veterinario(idVeterinario),
CPF char(12) not null,
DataCadastro Date not null
);
Go

Create Table Atendimento(
idAtendimento int Primary Key identity(1,1),
idVeterinario Smallint Foreign Key references Veterinario(idVeterinario),
idPet int Foreign Key references Pets(idPet),
DataConsulta Date not null,
Descrição Varchar(200) 
);
Go
