using senai_hroades_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroades_webAPI.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os Personagem
        /// </summary>
        /// <returns>Uma lista de Classes</returns>
        List<PersonagemDomain> Listar();

        /// <summary>
        /// Busca uma Personagem através do seu id
        /// </summary>
        /// <param name="idPersonagem">ID da Personagem que será buscado</param>
        /// <returns>Uma Personagem encontrada</returns>
        PersonagemDomain BuscarPorId(int idPersonagem);

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novopersonagem com os dados que serão cadastrados</param>
        void Cadastrar(PersonagemDomain novoPersonagem);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID do personagem que será atualizada</param>
        /// <param name="personagemAtualizada">Objeto PersonagemAtualizada com as novas informações</param>
        void Atualizar(short idPersonagem, PersonagemDomain personagemAtualizada);

        /// <summary>
        /// Deleta uma Personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID da Personagem que será deletada</param>
        void Deletar(int idPersonagem);
    }
}
