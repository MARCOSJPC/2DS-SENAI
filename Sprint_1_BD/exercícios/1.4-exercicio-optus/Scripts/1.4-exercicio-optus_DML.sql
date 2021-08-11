

Use OPTUS;
Go

Insert Into Plataforma(Nome_Plataforma)
Values ('Optus Music');
Go

Insert Into Artista(Nome_Artista)
Values ('Emicida'),('Racionais Mcs'),('Tim Maia');
Go

Insert Into Estilo_Musical(Nome_Estilo)
Values ('Rap'),('Soul'),('Funk');
Go

Insert Into Ativação_Album(Situação)
Values ('Ativado'),('Desativado');
Go

Insert Into Permissão_Usuario(Tipo_Permissão)
Values ('Administrador'),('Comum');
Go

Insert Into Usuario(Nome_Usuario,idPermissão)
Values ('Erika',1),('Marcos',1),('Alan',2);
Go

Insert Into Dados_de_Acesso(End_Email,Senha,idUsuario)
Values ('marcso@email.com','123456',2),('Erika@email.com','456789',1),('alan@email.com','987321',3);
Go

Insert Into Album(Nome_Album,idArtista,Data_Lançamento,Quant_min,idAtivação)
Values ('Sobrevivendo no inferno',2,'20/12/1997','00:73:00',1),('AmarElo',1,'30/10/2019','00:49:00',1),('O Descobridor dos Sete Mares',3,'03/01/1983','00:46:00',1);
Go

Insert Into Estilo_do_Album(idAlbum,idEstilo)
Values (1,1),(2,1),(3,2),(3,3);
Go