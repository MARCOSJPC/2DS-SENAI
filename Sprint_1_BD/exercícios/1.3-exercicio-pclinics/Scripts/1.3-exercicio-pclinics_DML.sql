
Use PCLINICS;
Go

Insert Into Clinica(NomeClinica,EndClinica)
Values ('Choupana dos animais','Rua Martin Luther King Jr, 70');
Go

Insert Into Dono(NomeDono)
Values ('Erika'),('Maros'),('Alan');
Go

Insert Into TipoPet(TipoPet)
Values ('Cachorro'),('Gato'),('Coelho');
Go

Insert into Ra�a(idTipoPet,RacaPet)
Values (2,'Siam�s'),(3,'Coelho Polon�s'),(1,'Labrador'),(1,'SRD'),;
Go

Insert Into Pets(idDono,idRa�a,NomePet,Data_Nasc)
Values	(1,2,'Hana','20/04/2014'),
		(1,1,'Bils','15/07/2015'),
		(2,3,'Marley','24/08/2010'),
		(3,4,'Anakin','05/06/2015');
Go

Insert Into Veterinario(NomeVet,CRMV)
Values ('Abner','51265/SP'),('Camila','40026/SP');
Go

insert Into Cadastro (idVeterinario,CPF,DataCadastro)
Values	(1,'123456789-00','10/04/2021'),
		(2,'987654321-02','03/05/2021')
Go

Insert Into Atendimento (idVeterinario,idPet,DataConsulta,Descri��o)
Values	(2,3,'05/06/2021','Carrapatos'),
		(1,2,'10/07/2021','doen�a gastrointestinal'),
		(1,1,'17/08/2021','Doen�a dermatol�gica');
Go
