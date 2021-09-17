using Microsoft.AspNetCore.Authorization;
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
/// Controller responsavel pelos endpoints referentes aos Personagens.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/personagens
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        /// <summary>
        /// Objeto _personagemRepository que irá receber todos os metodos definidor na interface IPersonagemRepository
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _personagemRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>Uma lista de Personagens e um status code.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR, JOGADOR)
        [Authorize(Roles = "ADMINISTRADOR, JOGADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.Listar());
        }

        /// <summary>
        /// Busca o id Personagem
        /// </summary>
        /// <returns>O id buscado um status code.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_personagemRepository.BuscarPorId(idPersonagem));
        }


        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <returns>Um status code de que foi cadastrado o novo personagem.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (JOGADOR)
        [Authorize(Roles = "JOGADOR")]
        [HttpPost]
        public IActionResult Cadastrar(PersonagemDomain novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um personagem selecionado pelo id
        /// </summary>
        /// <returns>Status code que foi deletado o personagem escolhido pelo id.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _personagemRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza personagem pelo seu id
        /// </summary>
        /// <returns>Status code que foi atualizado com sucesso.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(short idPersonagem, PersonagemDomain PersonagemAtualizada)
        {
            _personagemRepository.Atualizar(idPersonagem, PersonagemAtualizada);

            return StatusCode(204);
        }
    }
}
