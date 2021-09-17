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
/// Controller responsavel pelos endpoints referentes aos Tipo de Usuarios.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/tipousuarios
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoUsuarioRepository que irá receber todos os metodos definidor na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _tipoUsuarioRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Tipo de Usuarios
        /// </summary>
        /// <returns>Uma lista Tipo de Usuarios e um status code.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }


        /// <summary>
        ///  Busca um tipo de Usuario por Id
        /// </summary>
        /// <returns>O id buscado um status code.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(byte idTipoUsuario)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(idTipoUsuario));
        }

        /// <summary>
        /// Cadastrar um novo Tipo de Usuario
        /// </summary>
        /// <returns>Um status code de que foi cadastrado o novo tipo de usuario.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Tipo de Usuario através do seu id
        /// </summary>
        /// <returns>Status code que foi deletado o tipo de usuario escolhido pelo id.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(byte idTipoUsuario)
        {
            _tipoUsuarioRepository.Deletar(idTipoUsuario);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualizar um Tipo de Usuario existente através do seu id
        /// </summary>
        /// <returns>Status code que foi atualizado com sucesso.</returns>
        /// Authorize - Autorização de quem pode te acesso
        /// Roles - Os Autorizados (ADMINISTRADOR)
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{idTipoUsuario}")]
        public IActionResult Atualizar(byte idTipoUsuario, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(idTipoUsuario, tipoUsuarioAtualizado);

            return StatusCode(204);
        }

    }
}
