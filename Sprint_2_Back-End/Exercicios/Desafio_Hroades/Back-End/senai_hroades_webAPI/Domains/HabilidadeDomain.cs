using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class HabilidadeDomain
    {
        public HabilidadeDomain()
        {
            HabilidadeClasses = new HashSet<HabilidadeClasseDomain>();
        }

        public short IdHabilidade { get; set; }
        public short? IdTipo { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidadeDomain IdTipoNavigation { get; set; }
        public virtual ICollection<HabilidadeClasseDomain> HabilidadeClasses { get; set; }
    }
}
