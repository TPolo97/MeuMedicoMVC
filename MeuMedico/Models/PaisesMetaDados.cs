using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.Models
{
    [MetadataType(typeof(PaisesMetaDados))]
    public class PaisesMetaDados
    {
        [Required(ErrorMessage = "Obrigatorio informar país")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a sigla")]
        public string Sigla { get; set; }
    }
}