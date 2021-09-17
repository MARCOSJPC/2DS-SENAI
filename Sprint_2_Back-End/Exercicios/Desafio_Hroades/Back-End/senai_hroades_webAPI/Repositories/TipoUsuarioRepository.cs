using Microsoft.EntityFrameworkCore;
using senai_hroades_webAPI.Contexts;
using senai_hroades_webAPI.Domains;
using senai_hroades_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroades_webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadesContext ctx = new HroadesContext();

        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="IdTipoUsuario">IdTipoUsuario irá receber valores no parametro da função</param>
        /// <param name="tipoUsuarioAtualizado">tipoUsuarioAtualizado irá receber valores no parametro da função</param>
        public void Atualizar(byte IdTipoUsuario, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = ctx.TipoUsuarios.Find(IdTipoUsuario);

            if (tipoUsuarioAtualizado.Titulo != null)
            {
                tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

                ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

                ctx.SaveChanges();
            }
        }


        /// <summary>
        /// Buscar pelo id Tipo de Usuario
        /// </summary>
        /// <param name="IdTipoUsuario">Objeto IdTipoUsuario irá buscar o id pelas informações orientadas</param>
        /// <returns>O IdTipoUsuario buscado</returns>
        public TipoUsuarioDomain BuscarPorId(byte IdTipoUsuario)
        {
            //Retorna o id buscado na consulta
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == IdTipoUsuario);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com as informações que serão cadastradas</param>
        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            // Adiciona um novo TipoUsuario
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="IdTipoUsuario">Objeto IdTipoUsuario que será deletado</param>
        public void Deletar(byte IdTipoUsuario)
        {
            //Deleta um Tipo de Usuario
            ctx.TipoUsuarios.Remove(BuscarPorId(IdTipoUsuario));

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de todas os Tipos de Usuarios
        /// </summary>
        /// <returns>Lista de Tipos de Usuarios</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            // Retorna uma lista de Habilidades
            return ctx.TipoUsuarios.ToList();
        }


    }
}
