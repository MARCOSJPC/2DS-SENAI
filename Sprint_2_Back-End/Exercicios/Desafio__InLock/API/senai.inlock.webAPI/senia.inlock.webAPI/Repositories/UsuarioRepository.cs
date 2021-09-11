using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source=LAPTOP-TVA27R8T\SQLEXPRESS; initial catalog=inlock_games_tarde; user id=sa; pwd=senai@132";
        //  private string stringConexao = @"Data Source=LAPTOP-TVA27R8T\SQLEXPRESS; initial catalog=T_Rental; integrated security=true";
        public void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idUsuario, UsuarioDomain usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

       





        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {

                string querySelect = @"SELECT idUsuario, email, senha, titulo, Usuarios.idTipoUsuario
                                       FROM USUARIOS 
									   inner join TipoUsuario
									   on TipoUsuario.idTipoUsuario = Usuarios.idTipoUsuario
                                        WHERE email = @email and senha = @senha";


                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read()) 
                    {

                        UsuarioDomain usuarioBuscado = new UsuarioDomain

                        {
                          

                        idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = (rdr["email"]).ToString(),
                            senha = (rdr["senha"]).ToString(),
                            idTipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = (rdr["titulo"]).ToString()
                            },


                        };

                        return usuarioBuscado;


                    
                    }
                    return null;

                }





            }

            

        }

        public UsuarioDomain BuscarPorId(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
