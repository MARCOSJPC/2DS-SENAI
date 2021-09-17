using senai_hroades_webAPI.Domains;
using System.Collections.Generic;

namespace senai_hroades_webAPI.Interfaces
{
    /// <summary>
    /// Interface Responsavel pelo repositorio HabilidadeRepository
    /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de Habilidades</returns>
        List<HabilidadeDomain> Listar();

        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="idEstudio">ID da Habilidade que será buscado</param>
        /// <returns>Uma Habilidade encontrada</returns>
        HabilidadeDomain BuscarPorId(int idHabilidade);

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com os dados que serão cadastrados</param>
        void Cadastrar(HabilidadeDomain novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID da Habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        void Atualizar(short idHabilidade, HabilidadeDomain habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID da Habilidade que será deletada</param>
        void Deletar(int idHabilidade);

    }
}
