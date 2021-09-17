using senai_hroades_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroades_webAPI.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as Classes
        /// </summary>
        /// <returns>Uma lista de Classes</returns>
        List<ClasseDomain> Listar();

        /// <summary>
        /// Busca uma Classe através do seu id
        /// </summary>
        /// <param name="idClasse">ID da Classe que será buscado</param>
        /// <returns>Uma Classe encontrada</returns>
        ClasseDomain BuscarPorId(int idClasse);

        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse com os dados que serão cadastrados</param>
        void Cadastrar(ClasseDomain novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="idClasse">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(short idClasse, ClasseDomain classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="idClasse">ID da classe que será deletada</param>
        void Deletar(int idClasse);

       


    }
}
