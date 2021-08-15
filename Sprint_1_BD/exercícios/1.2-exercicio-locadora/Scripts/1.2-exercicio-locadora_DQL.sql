Use LOCADORA;
GO

--listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT idAluguel, Data_Retirda,Data_Devolução, Nome_Cliente, Nome_Modelo, Aluguel.idVeiculos  From Aluguel
Left join Cliente
ON Cliente.idCliente = Aluguel.idCliente
inner join Veiculos
on Aluguel.idVeiculos = Veiculos.idVeiculos
inner join Modelo
on Veiculos.idModelo = Modelo.idModelo

--listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
Select idAluguel, Aluguel.idVeiculos, Nome_Cliente, Data_Retirda, Data_Devolução, Nome_Modelo From Aluguel
inner join Cliente
on Cliente.idCliente = Aluguel.idCliente
inner join Veiculos
on Aluguel.idVeiculos = Veiculos.idVeiculos
inner join Modelo
on Veiculos.idModelo = Modelo.idModelo
Where Cliente.idCliente = 2