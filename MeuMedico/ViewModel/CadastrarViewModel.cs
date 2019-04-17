using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.ViewModel
{
    public class CadastrarViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar o email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo de 8 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmação não estao iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}