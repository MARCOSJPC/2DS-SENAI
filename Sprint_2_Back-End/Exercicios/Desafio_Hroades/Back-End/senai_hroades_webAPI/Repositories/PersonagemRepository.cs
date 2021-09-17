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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadesContext ctx = new HroadesContext();

        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="idPersonagem">idPersonagem irá receber valores no parametro da função</param>
        /// <param name="personagemAtualizada">personagemAtualizada irá receber valores no parametro da função</param>
        public void Atualizar(short idPersonagem, PersonagemDomain personagemAtualizada)
        {
            PersonagemDomain PersonagemBuscada = ctx.Personagems.Find(idPersonagem);

            if (personagemAtualizada.NomePersonagem != null)
            {
                PersonagemBuscada.NomePersonagem = personagemAtualizada.NomePersonagem;

                ctx.Personagems.Update(PersonagemBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar pela id Personagem
        /// </summary>
        /// <param name="idPersonagem">Objeto idPersonagem irá buscar o id pelas informações orientadas</param>
        /// <returns>O idPersonagem buscado</returns>
        public PersonagemDomain BuscarPorId(int idPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == idPersonagem);
        }

        /// <summary>
        /// Cadastra uma nova Personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as informações que serão cadastradas</param>
        public void Cadastrar(PersonagemDomain novoPersonagem)
        {
            // Adiciona uma nova Personagem
            ctx.Personagems.Add(novoPersonagem);
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Personagem
        /// </summary>
        /// <param name="idPersonagem">Objeto idPersonagem que será deletado</param>
        public void Deletar(int idPersonagem)
        {
            //Deleta um Personagem
            ctx.Personagems.Remove(BuscarPorId(idPersonagem));

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de todas as Personagens
        /// </summary>
        /// <returns>Lista de Personagens</returns>
        public List<PersonagemDomain> Listar()
        {
            // Retorna uma lista de Personagens junto das suas Classes
            return ctx.Personagems.Include(e => e.IdClasseNavigation).ToList();
        }
    }
}
