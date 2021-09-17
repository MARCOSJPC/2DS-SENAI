using senai_hroades_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroades_webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipo de Usuarios
        /// </summary>
        /// <returns>Uma lista de Classes</returns>
        List<TipoUsuarioDomain> Listar();

        /// <summary>
        /// Busca um Tipo de Usuario através do seu id
        /// </summary>
        /// <param name="IdTipoUsuario">ID do Tipo de Usuario que será buscado</param>
        /// <returns>Um Tipo de Usuario encontrado</returns>
        TipoUsuarioDomain BuscarPorId(byte IdTipoUsuario);

        /// <summary>
        /// Cadastra uma novo Tipo de Usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(TipoUsuarioDomain novoTipoUsuario);

        /// <summary>
        /// Atualiza um Tipo de Usuario existente
        /// </summary>
        /// <param name="IdTipoUsuario">ID do Tipo de Usuario que será atualizada</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações</param>
        void Atualizar(byte IdTipoUsuario, TipoUsuarioDomain tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um Tipo de Usuario existente
        /// </summary>
        /// <param name="IdTipoUsuario">ID do Tipo de Usuario que será deletada</param>
        void Deletar(byte IdTipoUsuario);

       
    }
}
