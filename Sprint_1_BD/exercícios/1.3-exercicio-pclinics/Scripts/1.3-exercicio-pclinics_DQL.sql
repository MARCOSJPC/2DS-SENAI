USE PCLINICS;
GO

SELECT * FROM Clinica;
GO

SELECT * FROM TipoPet;
GO

SELECT * FROM Raca;
GO

SELECT * FROM Dono;
GO

SELECT * FROM Veterinario;
GO

SELECT * FROM Pets;
GO

SELECT * FROM Atendimento;
GO

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT NomeVet, crmv, NomeClinica FROM veterinario
INNER JOIN Clinica
ON Clinica.idClinica = Veterinario.idClinica
WHERE Clinica.idClinica = 1;

-- listar todas as raças que começam com a letra S
SELECT * FROM Raca
WHERE RacaPet LIKE 's%';

-- listar todos os tipos de pet que terminam com a letra O
SELECT * FROM TipoPet
WHERE TipoPet LIKE '%o';

-- listar todos os pets mostrando os nomes dos seus donos
-- ALIAS (apelido) AS
SELECT idPet, NomePet AS pet, DataNasc 'Data nascimento', NomeDono dono 
FROM Pets
LEFT JOIN Dono
ON Dono.idDono = Pets.idDono;

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, 
-- o nome, a raça e o tipo do pet que foi atendido,
-- o nome do dono do pet e o nome da clínica onde o pet foi atendido
SELECT idAtendimento, NomeVet [veterinário], NomePet pet, RacaPet [Raça],
TipoPet [Espécie], NomeDono dono, NomeClinica [Razão social]
FROM Atendimento AS A
LEFT JOIN Veterinario V
ON A.idVeterinario = V.idVeterinario
INNER JOIN Pets P
ON A.idPet = P.idPet
INNER JOIN Raca R
ON P.idRaca = R.idRaca
INNER JOIN TipoPet TP
ON R.idTipoPet = TP.idTipoPet
INNER JOIN Dono D
ON P.idDono = D.idDono
LEFT JOIN Clinica C
ON V.idClinica = C.idClinica;
