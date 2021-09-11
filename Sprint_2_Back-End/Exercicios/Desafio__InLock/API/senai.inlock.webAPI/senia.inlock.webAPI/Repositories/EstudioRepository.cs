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
    /// Classe responsável pelo repositório dos Estudio
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source= Nome do Servidor
        /// initial catalog = Nome do Banco de Dados
        /// user ID= sa; pwd= senai@132 = Faz autenticação com o SQL SERVER passando o Login e Senha.
        /// integrated security=true = Faz autenticação com o usuario do sistema (Windows)
        /// Atualiza o corpo inteiro da tabela estudio
        /// </summary>
        private string stringConexao = @"Data Source=LAPTOP-TVA27R8T\SQLEXPRESS; initial catalog=inlock_games_tarde; user id=sa; pwd=senai@132";
        //  private string stringConexao = @"Data Source=LAPTOP-TVA27R8T\SQLEXPRESS; initial catalog=T_Rental; integrated security=true";
        public void AtualizarIdCorpo(EstudioDomain estudioAtualizado)
        {
            if (estudioAtualizado.nomeEstudio != null)
            {
                //Declara a SqlConnection con passando a string de conexao como Parametro.
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Estudios SET nomeEstudio = @nomeEstudio WHERE idEstudio = @idEstudio";

                    //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        //Atribui o valor nomeEstudio a variavel
                        cmd.Parameters.AddWithValue("@nomeEstudio", estudioAtualizado.nomeEstudio);

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
        /// <param name="idEstudio">idEstudio irá receber valores no parametro da função</param>
        /// <param name="estudioAtualizado">estudioAtualizado irá receber valores no parametro da função</param>
        public void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Estudios SET nomeEstudio = @nomeEstudio WHERE idEstudio = @idEstudio";

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Atribui o valor nomeEstudio a variavel
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudioAtualizado.nomeEstudio);

                    //Atribui o valor idEstudio a variavel
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    //Abre a conexão com o banco de dados.
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Buscar pelo id das colunas do estudio
        /// </summary>
        /// <param name="idEstudio">Objeto idEstudio irá buscar o id pelas informações orientadas</param>
        /// <returns>O idEstudio buscado</returns>
        public EstudioDomain BuscarPorId(int idEstudio)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idEstudio, nomeEstudio FROM Estudios WHERE idEstudio = @idEstudio";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando  SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Atribui o valor idEstudio a variavel
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    //executa a query e armeza os dados no rdr. 
                    rdr = cmd.ExecuteReader();

                    //instancia um objeto genero do tipo EstudioDomain
                    if (rdr.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            //atribui a propriedade idEstudio o valor da primeira coluna do bando de dados.
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            //atribui a propriedade nomeEstudio o valor da segunda coluna do bando de dados.
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };
                        //Retorna o estudio buscado pelo id
                        return estudioBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com as informações que serão cadastradas</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO Estudios (nomeEstudio) VALUES (@nomeEstudio)";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Atribui o valor idEstudio a variavel
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);

                    //Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Deleta um estudio
        /// </summary>
        /// <param name="idEstudio">Objeto idEstudio que será deletado</param>
        public void Deletar(int idEstudio)
        {
            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Estudios WHERE idEstudio = @idEstudio";

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Atribui o valor idEstudio a variavel
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    //Abre a conexão com o banco de dados.
                    con.Open();

                    //Executa a Query no banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista de todos os Estudios
        /// </summary>
        /// <returns>Lista de Estudios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = @"SELECT idEstudio, nomeEstudio FROM Estudios";

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
                        //instancia um objeto estudio do tipo EstudioDomain
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            //atribui a propriedade idEstudio o valor da primeira coluna do bando de dados.
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            //atribui a propriedade nomeEstudio a valor da segunda coluna da tabela do banco de dados.
                            nomeEstudio = rdr["nomeEstudio"].ToString()

                        };

                        //adiciona o objeto estudio criado a lista listaEstudio
                        listaEstudio.Add(estudio);

                    }
                }

            };

            //Retorna a lista estudio
            return listaEstudio;
        }
    }
}
