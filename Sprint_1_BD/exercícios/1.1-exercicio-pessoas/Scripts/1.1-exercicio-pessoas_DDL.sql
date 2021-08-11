Create Database EMPRESA;
Go

Use EMPRESA;
Go 

Create Table Pessoa (
 idPessoa Smallint Primary key  identity(1,1),
 Nome_Pessoa Varchar(20) NOT NULL
);
Go 

Create Table Telefone (
  idTelefone Smallint Primary key identity(1,1),
  idPessoa Smallint Foreign Key references Pessoa(idPessoa),
  Numero_telefone Varchar(15) NOT NULL
);
Go

Create Table Email (
  idEmail Int Primary key identity(1,1),
  idPessoa Smallint Foreign Key references Pessoa(idPessoa),
  End_email Varchar(256) NOT NULL
);
Go 

Create Table CNH(
 idCNH Smallint Primary key identity(1,1), 
 idPessoa Smallint Foreign Key references Pessoa(idPessoa),
 Descricao Char(11) NOT NULL Unique
);
Go 
