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
/// Controller responsavel pelos endpoints referentes aos Tipo de Habilidade.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/tipohabilidades
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class TipoHabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoHabilidadeRepository que irá receber todos os metodos definidor na interface ITipoHabilidadeRepository
        /// </summary>
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _tipoHabilidadeRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os Tipo de Habilidade
        /// </summary>
        /// <returns>Uma lista de Tipo de Habilidade e um status code.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoHabilidadeRepository.Listar());
        }


        /// <summary>
        /// Busca um tipo de Habilidade por Id
        /// </summary>
        /// <returns>O id buscado um status code.</returns>
        [HttpGet("{idTipo}")]
        public IActionResult BuscarPorId(int idTipo)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(idTipo));
        }

        /// <summary>
        /// Cadastrar um novo Tipo de Habilidade
        /// </summary>
        /// <returns>Um status code de que foi cadastrado o novo tipo de habilidade.</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidadeDomain novoTipo)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }


        /// <summary>
        /// Deleta um Tipo de Habilidade através do seu id
        /// </summary>
        /// <returns>Status code que foi deletado o tipo de habilidade escolhido pelo id.</returns>
        [HttpDelete("{idTipo}")]
        public IActionResult Deletar(int idTipo)
        {
            _tipoHabilidadeRepository.Deletar(idTipo);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualizar um Tipo de Habilidade existente através do seu id
        /// </summary>
        /// <returns>Status code que foi atualizado com sucesso.</returns>
        [HttpPut("{idTipo}")]
        public IActionResult Atualizar(short idTipo, TipoHabilidadeDomain tipoAtualizado)
        {
            _tipoHabilidadeRepository.Atualizar(idTipo, tipoAtualizado);

            return StatusCode(204);
        }

    }
}
