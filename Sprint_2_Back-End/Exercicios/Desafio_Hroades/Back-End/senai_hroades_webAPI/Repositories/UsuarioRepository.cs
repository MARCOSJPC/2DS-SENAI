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
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadesContext ctx = new HroadesContext();


        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="IdUsuario">IdUsuario irá receber valores no parametro da função</param>
        /// <param name="usuarioAtualizado">usuarioAtualizado irá receber valores no parametro da função</param>
        public void Atualizar(int IdUsuario, UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = ctx.Usuarios.Find(IdUsuario);

            if (usuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;

                ctx.Usuarios.Update(usuarioBuscado);

                ctx.SaveChanges();
                
            }
        }

        /// <summary>
        /// Busca pelo email e senha do Usuario
        /// </summary>
        /// <param name="email">parâmentro email para buscar</param>
        /// <param name="senha">parâmentro senha para buscar</param>
        /// <returns>email e senha do usuario cadastrado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            //Retorna email e senha junto do tipo de usuario cadastrado
            return ctx.Usuarios.Include(e => e.IdTipoUsuarioNavigation).FirstOrDefault(e => e.Email == email && e.Senha == senha );
        }

        /// <summary>
        /// Buscar pelo id Usuario
        /// </summary>
        /// <param name="IdUsuario">Objeto IdUsuario irá buscar o id pelas informações orientadas</param>
        /// <returns>O IdUsuario buscado</returns>
        public UsuarioDomain BuscarPorId(int IdUsuario)
        {
            //Retorna o id buscado na consulta
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == IdUsuario);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações que serão cadastradas</param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            // Adiciona um novo Usuario
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="IdUsuario">Objeto IdUsuario que será deletado</param>
        public void Deletar(int IdUsuario)
        {
            //Deleta um Usuario
            ctx.Usuarios.Remove(BuscarPorId(IdUsuario));

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de todas os Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        public List<UsuarioDomain> Listar()
        {
            // Retorna uma lista de Usuarios e Tipo de Usuarios
            return ctx.Usuarios.Include(e => e.IdTipoUsuarioNavigation).ToList();
            
        }

      
    }
}
