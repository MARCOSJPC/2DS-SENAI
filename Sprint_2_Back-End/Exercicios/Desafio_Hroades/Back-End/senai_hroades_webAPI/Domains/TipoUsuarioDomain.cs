using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class TipoUsuarioDomain
    {
        public TipoUsuarioDomain()
        {
            Usuarios = new HashSet<UsuarioDomain>();
        }

        public byte IdTipoUsuario { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<UsuarioDomain> Usuarios { get; set; }
    }
}
