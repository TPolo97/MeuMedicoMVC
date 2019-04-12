using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.Models
{
    [MetadataType(typeof(UsuarioMetaDados))]
    public class UsuarioMetaDados
    {

        [Required(ErrorMessage = "Obrigatorio informar o usuario")]
        [StringLength(30, ErrorMessage = "Usuario muito grande")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a senha")]
        [StringLength(10, ErrorMessage = "Senha invalida")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o nome")]
        [StringLength(20)]
        public string Nome { get; set; }

    }
}