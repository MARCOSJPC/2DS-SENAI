using senai_hroades_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroades_webAPI.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os Tipo de Habilidade
        /// </summary>
        /// <returns>Uma lista de Tipo de Habilidade</returns>
        List<TipoHabilidadeDomain> Listar();

        /// <summary>
        /// Busca um Tipo de Habilidade através do seu id
        /// </summary>
        /// <param name="IdTipo">ID do Tipo de Habilidade que será buscado</param>
        /// <returns>Uma Classe encontrada</returns>
        TipoHabilidadeDomain BuscarPorId(int IdTipo);

        /// <summary>
        /// Cadastra uma nov Tipo de Habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo com os dados que serão cadastrados</param>
        void Cadastrar(TipoHabilidadeDomain novoTipo);

        /// <summary>
        /// Atualiza um Tipo de Habilidade existente
        /// </summary>
        /// <param name="IdTipo">ID do Tipo de Habilidade que será atualizada</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
        void Atualizar(short IdTipo, TipoHabilidadeDomain tipoAtualizado);

        /// <summary>
        /// Deleta um Tipo de Habilidade existente
        /// </summary>
        /// <param name="IdTipo">ID do Tipo de Habilidade que será deletada</param>
        void Deletar(int IdTipo);

    
    }
}
