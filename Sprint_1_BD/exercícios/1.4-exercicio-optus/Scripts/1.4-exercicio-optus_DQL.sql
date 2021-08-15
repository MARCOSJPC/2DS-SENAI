USE OPTUS;
Go
--listar todos os usuários administradores, sem exibir suas senhas
SELECT idUsuario, Nome_Usuario, Tipo_Permissão FROM Usuario
inner join Permissão_Usuario
On Permissão_Usuario.idPermissão = Usuario.idPermissão
where Permissão_Usuario.idPermissão = 1

--listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT * FROM Album where Data_Lançamento between '1995-05-02' and '2021-08-15'

--listar os dados de um usuário através do e-mail e senha
SELECT Nome_Usuario, Tipo_Permissão From Dados_de_Acesso
inner join Usuario
On Usuario.idUsuario = Dados_de_Acesso.idUsuario
inner join Permissão_Usuario
On Usuario.idPermissão = Permissão_Usuario.idPermissão

--listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
SELECT Nome_Album, Nome_Artista,Nome_Estilo FROM Album
inner join Artista
On Artista.idArtista = Album.idArtista
inner join Estilo_do_Album
On Estilo_do_Album.idAlbum = Album.idAlbum
inner join Estilo_Musical
On Estilo_do_Album.idEstilo = Estilo_Musical.idEstilo
Where Album.idAtivação = 1