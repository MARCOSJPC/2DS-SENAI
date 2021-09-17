using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_hroades_webAPI.Domains;
using senai_hroades_webAPI.Interfaces;
using senai_hroades_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsavel pelos endpoints referentes aos Habilidades.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/habilidades
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os metodos definidor na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _habilidadeRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>uma lista de habilidades com status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_habilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca uma habilidade através do seu id
        /// </summary>
        /// <param name="idHabilidade">id da Habilidade que será buscada</param>
        /// <returns>uma habilidade com status code 200 - Ok</returns>
        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarPorId(int idHabilidade)
        {
            return Ok(_habilidadeRepository.BuscarPorId(idHabilidade));
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto com os dados que serão cadastrados</param>
        /// <returns>um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(HabilidadeDomain novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma habilidade através do seu id
        /// </summary>
        /// <param name="idHabilidade">id da Habilidade que será deletada</param>
        /// <returns>um status code 204 - No Content</returns>
        [HttpDelete("{idHabilidade}")]
        public IActionResult Deletar(int idHabilidade)
        {
            _habilidadeRepository.Deletar(idHabilidade);

            return StatusCode(204);
        }
 
    }
}
