using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        public void AtualizarIdCorpo(TipoUsuarioDomain tipousuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idTipoUsuario, TipoUsuarioDomain tipousuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDomain BuscarPorId(int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
