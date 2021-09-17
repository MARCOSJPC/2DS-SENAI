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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadesContext ctx = new HroadesContext();

        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="idHabilidade">idHabilidade irá receber valores no parametro da função</param>
        /// <param name="habilidadeAtualizada">habilidadeAtualizada irá receber valores no parametro da função</param>
        public void Atualizar(short idHabilidade, HabilidadeDomain habilidadeAtualizada)
        {
            HabilidadeDomain habilidadeBuscada = ctx.Habilidades.Find(idHabilidade);

            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar pelo id habilidade
        /// </summary>
        /// <param name="idHabilidade">Objeto idHabilidade irá buscar o id pelas informações orientadas</param>
        /// <returns>O idHabilidade buscado</returns>
        public HabilidadeDomain BuscarPorId(int idHabilidade)
        {
            //Retorna o id buscado na consulta
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == idHabilidade);
        }


        /// <summary>
        /// Cadastra um nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com as informações que serão cadastradas</param>
        public void Cadastrar(HabilidadeDomain novaHabilidade)
        {
            // Adiciona uma novaHabilidade
            ctx.Habilidades.Add(novaHabilidade);
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade
        /// </summary>
        /// <param name="idHabilidade">Objeto idHabilidade que será deletado</param>
        public void Deletar(int idHabilidade)
        {

            //Deleta uma Habilidade
            ctx.Habilidades.Remove(BuscarPorId(idHabilidade));
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de todas as Habilidades
        /// </summary>
        /// <returns>Lista de Habilidades</returns>
        public List<HabilidadeDomain> Listar()
        {
            // Retorna uma lista de Habilidades junto dos tipos de habilidades
            return ctx.Habilidades.Include(e => e.IdTipoNavigation).Include(e => e.HabilidadeClasses).ToList();
        }

    
    }
}
