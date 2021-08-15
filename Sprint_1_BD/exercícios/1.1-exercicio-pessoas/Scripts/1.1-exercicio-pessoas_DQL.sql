Use EMPRESA;
Go

--listar as pessoas em ordem alfabética reversa, mostrando seus telefones, seus e-mails e suas CNHs

Select Pessoa.IdPessoa, Nome_Pessoa, End_email, Numero_telefone, Descricao From Pessoa 
left Join Email
On Email.idPessoa = Pessoa.idPessoa
Inner Join Telefone
On Telefone.idPessoa = Pessoa.idPessoa
Inner Join CNH
On CNH.idPessoa = Pessoa.idPessoa
Order by Nome_Pessoa desc 
