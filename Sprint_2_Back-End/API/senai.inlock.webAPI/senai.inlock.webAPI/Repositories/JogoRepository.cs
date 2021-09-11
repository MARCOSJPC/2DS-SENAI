using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Jogo
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source= Nome do Servidor
        /// initial catalog = Nome do Banco de Dados
        /// user ID= sa; pwd= senai@132 = Faz autenticação com o SQL SERVER passando o Login e Senha.
        /// integrated security=true = Faz autenticação com o usuario do sistema (Windows)
        /// Atualiza o corpo inteiro da tabela Jogos
        /// </summary>
        private string stringConexao = @"Data Source=LAPTOP-TVA27R8T\SQLEXPRESS; initial catalog=inlock_games_tarde; user id=sa; pwd=senai@132";
        //  private string stringConexao = @"Data Source=LAPTOP-TVA27R8T\SQLEXPRESS; initial catalog=T_Rental; integrated security=true";
        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        {
            if (jogoAtualizado.nomeJogo != null)
            {
                //Declara a SqlConnection con passando a string de conexao como Parametro.
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = @"UPDATE Jogos 
                                               SET nomeJogo = @nomeJogo, 
                                                   dataLancamento = @dataLancamento,
                                                   descricao = @descricao,
                                                   valor = @valor
                                                   WHERE idJogo = @idJogo";

                    //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        //Atribui o valor nomeJogo a variavel
                        cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);

                        //Atribui o valor dataLancamento a variavel
                        cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);

                        //Atribui o valor descricao a variavel
                        cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);

                        //Atribui o valor ao valor a variavel
                        cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);

                        //Abre a conexão com o banco de dados.
                        con.Open();

                        //Executa a query
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="idJogo">idJogo irá receber valores no parametro da função</param>
        /// <param name="jogoAtualizado">JogoAtualizado irá receber valores no parametro da função</param>
        public void AtualizarIdUrl(int idJogo, JogoDomain jogoAtualizado)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = @"UPDATE Jogos 
                                        SET nomeJogo = @nomeJogo, 
                                        dataLancamento = @dataLancamento, 
                                        descricao = @descricao, 
                                        valor = @valor 
                                        WHERE idJogo = @idJogo";

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Atribui o valor nomeJogo a variavel
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);

                    //Atribui o valor dataLancamento a variavel
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);

                    //Atribui o valor descricao a variavel
                    cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);

                    //Atribui o valor ao valor a variavel
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);

                    //Atribui o valor idJogo a variavel
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    //Abre a conexão com o banco de dados.
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Buscar pelo id das colunas do jogo
        /// </summary>
        /// <param name="idJogo">Objeto idJogo irá buscar o id pelas informações orientadas</param>
        /// <returns>O idJogo buscado</returns>
        public JogoDomain BuscarPorId(int idJogo)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT idJogo, nomeJogo, dataLancamento, descricao, valor 
                                           FROM Jogos 
                                           WHERE idJogo = @idJogo";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando  SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Atribui o valor idJogo a variavel
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    //executa a query e armeza os dados no rdr. 
                    rdr = cmd.ExecuteReader();

                    //instancia um objeto genero do tipo JogoDomain
                    if (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            //atribui a propriedade idJogo o valor da primeira coluna do bando de dados.
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            //atribui a propriedade nomeJogo o valor da segunda coluna do bando de dados.
                            nomeJogo = rdr["nomeJogo"].ToString(),

                            //atribui a propriedade dataLancamento o valor da terceira coluna do bando de dados.
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),

                            //atribui a propriedade valor ao valor da quarta coluna do bando de dados.
                            valor = Convert.ToInt32(rdr["valor"]),

                            //atribui a propriedade descricao o valor da terceira coluna do bando de dados.
                            descricao = rdr["descricao"].ToString()

                        };

                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com as informações que serão cadastradas</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO Jogos (nomeJogo, dataLancamento, descricao, valor) VALUES (@nomeJogo, @dataLancamento, @descricao, @valor)";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Atribui o valor nomeJogo a variavel
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);

                    //Atribui o valor dataLancamento a variavel
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);

                    //Atribui o valor descrição a variavel
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);

                    //Atribui o valor valor a variavel
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);

                    //Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="idJogo">Objeto idJogo que será deletado</param>
        public void Deletar(int idJogo)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Jogos WHERE idJogo = @idJogo";

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Atribui o valor idJogo a variavel
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    //Abre a conexão com o banco de dados.
                    con.Open();

                    //Executa a Query no banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista de todos os Jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idJogo, nomeJogo, descricao, valor, dataLancamento, jogos.idEstudio, nomeEstudio
                                            FROM Jogos 
                                            INNER JOIN Estudios 
                                            ON Jogos.idEstudio = Estudios.idEstudio";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando  SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armeza os dados no rdr.  
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //instancia um objeto jogo do tipo JogoDomain
                        JogoDomain jogo = new JogoDomain()
                        {
                            //atribui a propriedade idJogo o valor da primeira coluna do bando de dados.
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            //atribui a propriedade nomeJogo o valor da segunda coluna do bando de dados.
                            nomeJogo = rdr["nomeJogo"].ToString(),

                            //atribui a propriedade dataLancamento o valor da terceira coluna do bando de dados.
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),

                            //atribui a propriedade valor ao valor da quarta coluna do bando de dados.
                            valor = Convert.ToInt32(rdr["valor"]),

                            //atribui a propriedade descricao o valor da terceira coluna do bando de dados.
                            descricao = rdr["descricao"].ToString(),

                            //atribui a propriedade idEstudio o valor da a coluna da tabela estrangeira do bando de dados.
                            idEstudio = new EstudioDomain()
                            {
                                //atribui a propriedade idEstudio o valor na coluna idEstudio da tabela estrangeira Estudio 
                                idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                                //atribui a propriedade nomeEstudio o valor na coluna nomeEstudio da tabela estrangeira Estudio 
                                nomeEstudio = rdr["nomeEstudio"].ToString()

                            }
                        };

                        //adiciona o objeto jogo criado a lista listaJogo
                        listaJogo.Add(jogo);

                    }
                }

            };

            //Retorna a lista jogos
            return listaJogo;
        }
    }
}
