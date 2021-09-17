using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte? IdTipoUsuario { get; set; }

        public virtual TipoUsuarioDomain IdTipoUsuarioNavigation { get; set; }
    }
}
