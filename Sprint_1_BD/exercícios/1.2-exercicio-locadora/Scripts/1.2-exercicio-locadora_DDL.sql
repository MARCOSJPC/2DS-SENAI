Create Database LOCADORA;
Go

Use LOCADORA;
Go 

--drop table Empresa

Create Table Empresa (
 idEmpresa Tinyint Primary key  identity(1,1),
 Nome_Empresa Varchar(20) NOT NULL
);
Go 

Create Table Marca (
 idMarca Tinyint Primary key  identity(1,1),
 Nome_Marca Varchar(20) NOT NULL
);
Go 

Create Table Cliente (
 idCliente Smallint Primary key  identity(1,1),
 Nome_Cliente Varchar(20) NOT NULL
);
Go 


Create Table Veiculos (
  idVeiculos Smallint Primary key identity(1,1),
  idEmpresa Tinyint Foreign Key references Empresa(idEmpresa),
  idModelo Tinyint Foreign Key references Modelo(idModelo),
  Placa_veiculo Varchar(15) NOT NULL
);
Go

Create Table Modelo (
  idModelo Tinyint Primary key identity(1,1),
  idMarca Tinyint Foreign Key references Marca(idMarca),
  Nome_Modelo Varchar(40) NOT NULL
);
Go 

Create Table Aluguel(
 idAluguel Int Primary key identity(1,1), 
 idCliente Smallint Foreign Key references Cliente(idCliente),
 idVeiculos Smallint Foreign Key references Veiculos(idVeiculos),
 Data_Retirda char(10) not null 
);
Go 

/*
alter table Aluguel
add Data_Devolução char(10) not null
*/
