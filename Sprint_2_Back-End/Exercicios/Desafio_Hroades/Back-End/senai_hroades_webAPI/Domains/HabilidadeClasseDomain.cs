using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class HabilidadeClasseDomain
    {
        public short IdHabClasse { get; set; }
        public short? IdHabilidade { get; set; }
        public short? IdClasse { get; set; }

        public virtual ClasseDomain IdClasseNavigation { get; set; }
        public virtual HabilidadeDomain IdHabilidadeNavigation { get; set; }
    }
}
