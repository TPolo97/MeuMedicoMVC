//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeuMedico
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicos
    {
        public int IDMedico { get; set; }
        public Nullable<int> IDCidade { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public Nullable<bool> AtendePorConvenio { get; set; }
        public Nullable<bool> TemClinica { get; set; }
        public string WebSiteBlog { get; set; }
        public Nullable<short> IDEspecialidade { get; set; }
    
        public virtual Cidades Cidades { get; set; }
        public virtual Especialidades Especialidades { get; set; }
    }
}
