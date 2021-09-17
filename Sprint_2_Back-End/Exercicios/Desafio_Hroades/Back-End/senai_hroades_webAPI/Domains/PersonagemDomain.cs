using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroades_webAPI.Domains
{
    /// <summary>
    /// Referência o banco de dados tabelas e atributos 
    /// </summary>
    public partial class PersonagemDomain
    {
        public short IdPersonagem { get; set; }
        public short? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public string MaxMana { get; set; }
        public string MaxVida { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual ClasseDomain IdClasseNavigation { get; set; }
    }
}
