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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadesContext ctx = new HroadesContext();

        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="IdTipo">IdTipo irá receber valores no parametro da função</param>
        /// <param name="tipoAtualizado">tipoAtualizado irá receber valores no parametro da função</param>
        public void Atualizar(short IdTipo, TipoHabilidadeDomain tipoAtualizado)
        {
            TipoHabilidadeDomain tipoBuscado = ctx.TipoHabilidades.Find(IdTipo);

            if (tipoAtualizado.TipoHabilidade1 != null)
            {
                tipoBuscado.TipoHabilidade1 = tipoAtualizado.TipoHabilidade1;

                ctx.TipoHabilidades.Update(tipoBuscado);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar pelo id Tipo de Habilidade
        /// </summary>
        /// <param name="IdTipo">Objeto IdTipo irá buscar o id pelas informações orientadas</param>
        /// <returns>O IdTipo buscado</returns>
        public TipoHabilidadeDomain BuscarPorId(int IdTipo)
        {
            //Retorna o id buscado na consulta
            return ctx.TipoHabilidades.FirstOrDefault(e => e.IdTipo == IdTipo);
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo com as informações que serão cadastradas</param>
        public void Cadastrar(TipoHabilidadeDomain novoTipo)
        {
            // Adiciona um novoTipo
            ctx.TipoHabilidades.Add(novoTipo);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de habilidade
        /// </summary>
        /// <param name="IdTipo">Objeto IdTipo que será deletado</param>
        public void Deletar(int IdTipo)
        {
            //Deleta um Tipo de Habilidade
            ctx.TipoHabilidades.Remove(BuscarPorId(IdTipo));

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de todas os Tipos de Habilidades
        /// </summary>
        /// <returns>Lista de Tipos de Habilidades</returns>
        public List<TipoHabilidadeDomain> Listar()
        {
            // Retorna uma lista de Habilidades
            return ctx.TipoHabilidades.ToList();
        }

     
    }
}
