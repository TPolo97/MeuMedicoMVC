using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.Models
{
    [MetadataType(typeof(MedicoMetaDados))]

    public partial class Medicos
    {

    }

    public class MedicoMetaDados
    {
        [Required(ErrorMessage = "Obrigatorio informar CRM")]
        [StringLength(30, ErrorMessage = "CRM inválido")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar convenio")]
        public Boolean AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar clinica")]
        public Boolean Clinica { get; set; }

        [StringLength(30)]
        public string WebSiteBlog { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Cidade invalida")]
        public string IDCidade { get; set; }
    }
}