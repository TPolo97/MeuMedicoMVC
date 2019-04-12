using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.Models
{
    [MetadataType(typeof(EstadosMetaDados))]
    public class EstadosMetaDados
    {
        [Required(ErrorMessage = "Obrigatorio informar estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a sigla")]
        public string Sigla { get; set; }
    }
}