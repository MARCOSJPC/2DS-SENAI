USE OPTUS;
Go
--listar todos os usu�rios administradores, sem exibir suas senhas
SELECT idUsuario, Nome_Usuario, Tipo_Permiss�o FROM Usuario
inner join Permiss�o_Usuario
On Permiss�o_Usuario.idPermiss�o = Usuario.idPermiss�o
where Permiss�o_Usuario.idPermiss�o = 1

--listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
SELECT * FROM Album where Data_Lan�amento between '1995-05-02' and '2021-08-15'

--listar os dados de um usu�rio atrav�s do e-mail e senha
SELECT Nome_Usuario, Tipo_Permiss�o From Dados_de_Acesso
inner join Usuario
On Usuario.idUsuario = Dados_de_Acesso.idUsuario
inner join Permiss�o_Usuario
On Usuario.idPermiss�o = Permiss�o_Usuario.idPermiss�o

--listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 
SELECT Nome_Album, Nome_Artista,Nome_Estilo FROM Album
inner join Artista
On Artista.idArtista = Album.idArtista
inner join Estilo_do_Album
On Estilo_do_Album.idAlbum = Album.idAlbum
inner join Estilo_Musical
On Estilo_do_Album.idEstilo = Estilo_Musical.idEstilo
Where Album.idAtiva��o = 1