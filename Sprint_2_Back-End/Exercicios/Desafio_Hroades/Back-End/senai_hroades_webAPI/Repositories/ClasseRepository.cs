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
    public class ClasseRepository : IClasseRepository
    {
        HroadesContext ctx = new HroadesContext();

        /// <summary>
        /// Atualiza por id no escopo da URL
        /// </summary>
        /// <param name="idClasse">idClasse irá receber valores no parametro da função</param>
        /// <param name="classeAtualizada">classeAtualizada irá receber valores no parametro da função</param>
        public void Atualizar(short idClasse, ClasseDomain classeAtualizada)
        {
            ClasseDomain classeBuscada = ctx.Classes.Find(idClasse);

            if (classeAtualizada.TipoClasse != null)
            {
                classeBuscada.TipoClasse = classeAtualizada.TipoClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar pelo id classe
        /// </summary>
        /// <param name="idClasse">Objeto idClasse irá buscar o id pelas informações orientadas</param>
        /// <returns>O idClasse buscado</returns>
        public ClasseDomain BuscarPorId(int idClasse)
        {
            //Retorna o id buscado na consulta
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == idClasse);
        }

        /// <summary>
        /// Cadastra um nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse com as informações que serão cadastradas</param>
        public void Cadastrar(ClasseDomain novaClasse)
        {
            // Adiciona uma Classe
            ctx.Classes.Add(novaClasse);
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe
        /// </summary>
        /// <param name="idClasse">Objeto idClasse que será deletado</param>
        public void Deletar(int idClasse)
        {
            //Deleta uma Classe
            ctx.Classes.Remove(BuscarPorId(idClasse));
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de todas as Classes
        /// </summary>
        /// <returns>Lista de Classes</returns>
        public List<ClasseDomain> Listar()
        {
            // Retorna uma listar de Classes
            return ctx.Classes.ToList();
        }

    }
}
