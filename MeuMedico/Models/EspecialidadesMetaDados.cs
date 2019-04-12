using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.Models
{
    [MetadataType(typeof(EspecialidadesMetaDados))]
    public class EspecialidadesMetaDados
    {

        [Required(ErrorMessage = "Obrigatorio informar a especialidade")]
        public string Especialidade { get; set; }
    }
}