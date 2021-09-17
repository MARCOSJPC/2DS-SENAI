using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class ClasseDomain
    {
        public ClasseDomain()
        {
            HabilidadeClasses = new HashSet<HabilidadeClasseDomain>();
            Personagems = new HashSet<PersonagemDomain>();
        }

        public short IdClasse { get; set; }
        public string TipoClasse { get; set; }

        public virtual ICollection<HabilidadeClasseDomain> HabilidadeClasses { get; set; }
        public virtual ICollection<PersonagemDomain> Personagems { get; set; }
    }
}
