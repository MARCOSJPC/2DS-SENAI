

Use LOCADORA;
Go

Insert into Empresa(Nome_Empresa)
Values ('Unidas');
Go

insert into Marca(Nome_Marca)
Values ('Volkswagen'),('Fiat'),('Honda');
Go

Insert Into Modelo(idMarca,Nome_Modelo)
Values (2,'Idea'),(1,'Golf'),(3,'Civic'),(1,'Jeta');
Go

Insert Into Veiculos(idEmpresa,idModelo,Placa_veiculo)
Values (1,2,'AAA123'),(1,1,'MMM777'),(1,4,'EEE410'),(1,3,'ERK527');
Go

Insert Into Cliente(Nome_Cliente)
Values ('Erika'),('Marcos'),('Alan');
Go

Insert Into Aluguel(idVeiculos,idCliente,Data_Retirda,Data_Devolução)
Values (4,3,'04/09/2021','08/09/2021'),(3,1,'05/09/2021','07/09/2021'),(1,2,'06/09/2021','08/09/2021'),(3,2,'07/09/2021','10/09/2021'),(2,1,'10/09/2021','12/09/2021');
Go