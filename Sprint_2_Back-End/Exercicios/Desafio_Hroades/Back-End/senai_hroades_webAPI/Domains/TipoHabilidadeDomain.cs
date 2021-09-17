using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class TipoHabilidadeDomain
    {
        public TipoHabilidadeDomain()
        {
            Habilidades = new HashSet<HabilidadeDomain>();
        }

        public short IdTipo { get; set; }
        public string TipoHabilidade1 { get; set; }

        public virtual ICollection<HabilidadeDomain> Habilidades { get; set; }
    }
}
