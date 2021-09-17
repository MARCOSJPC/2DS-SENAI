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
/// Controller responsavel pelos endpoints referentes aos Usuarios.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/usuarios
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os metodos definidor na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _usuarioRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista Usuarios e um status code.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        ///  Busca um Usuario por Id
        /// </summary>
        /// <returns>O id buscado um status code.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_usuarioRepository.BuscarPorId(idUsuario));
        }

        /// <summary>
        /// Cadastrar um novo Usuario
        /// </summary>
        /// <returns>Um status code de que foi cadastrado o novo usuario.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(UsuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Tipo de Usuario através do seu id
        /// </summary>
        /// <returns>Status code que foi deletado o usuario escolhido pelo id.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualizar um Usuario existente através do seu id
        /// </summary>
        /// <returns>Status code que foi atualizado com sucesso.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idTipoUsuario, UsuarioDomain usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(idTipoUsuario, usuarioAtualizado);

            return StatusCode(204);
        }

    }
}
