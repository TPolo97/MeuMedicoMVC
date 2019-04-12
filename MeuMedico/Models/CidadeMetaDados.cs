using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.Models
{
    [MetadataType(typeof(CidadeMetaDados))]
    public class CidadeMetaDados
    {
        [Required(ErrorMessage = "Obrigatorio informar cidade")]
        public string Cidade { get; set; }
    }
}