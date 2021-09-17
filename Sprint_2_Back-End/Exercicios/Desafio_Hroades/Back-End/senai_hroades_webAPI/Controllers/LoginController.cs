using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_hroades_webAPI.Domains;
using senai_hroades_webAPI.Interfaces;
using senai_hroades_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// Controller responsavel pelos endpoints referentes ao Login.
/// </summary>
namespace senai_hroades_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/login
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class LoginController : ControllerBase
    {

        /// <summary>
        /// Objeto _UsuarioRepository que irá receber todos os metodos definidor na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _LoginRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _UsuarioRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public LoginController()
        {
            _LoginRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Gera um token para email cadastrados no sistema do banco de dados
        /// </summary>
        /// <param name="login">Objeto login utilizado para alocar os dados recebidos</param>
        /// <returns>retorna um token</returns>
        [HttpPost("login")]

        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _LoginRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha invalidos");
            }

            // Definição das claims de acesso
            var minhasClaims = new[]
            {

                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Titulo),
            };
            //Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-autenticacao-API-HROADES"));

            // Define as credenciais do token - signature
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Composição do Token
            var meuToken = new JwtSecurityToken(
                    issuer: "Senai.Hroades", //emissor do token
                    audience: "Senai.Hroades", // destinatario do token
                    claims: minhasClaims, //    dados definidos acima
                    expires: DateTime.Now.AddMinutes(30), // Tempo limite de duração do token
                    signingCredentials: creds // Credenciais

                );
            // Retorna o token criado apartir dos usuarios cadastrados
            return Ok(new
            {
               token = new JwtSecurityTokenHandler().WriteToken(meuToken)
            });

        }


    }
}
