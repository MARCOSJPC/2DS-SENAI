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
/// Controller responsavel pelos endpoints referentes aos Classes.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/classes
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os metodos definidor na interface IClasseRepository
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _classeRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as Classes 
        /// </summary>
        /// <returns>Uma lista de classes e um status code.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        /// <summary>
        /// Busca o id Classe
        /// </summary>
        /// <returns>O id buscado um status code.</returns>
        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        /// <summary>
        /// Cadastra um novo classe
        /// </summary>
        /// <returns>Um status code de que foi cadastrado o nova classe.</returns>
        [HttpPost]
        public IActionResult Cadastrar(ClasseDomain novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma classe selecionado pelo id
        /// </summary>
        /// <returns>Status code que foi deletado a classe escolhido pelo id.</returns>
        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classeRepository.Deletar(idClasse);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualizar uma Classe existente através do seu id
        /// </summary>
        /// <returns>Status code que foi atualizado.</returns>
        [HttpPut("{idClasse}")]
        public IActionResult Atualizar(short idClasse, ClasseDomain classeAtualizada)
        {
            _classeRepository.Atualizar(idClasse, classeAtualizada);

            return StatusCode(204);
        }

    }
}
