using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuMedico.ViewModel
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Repita a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare(nameof(NovaSenha), ErrorMessage = "Senhas não conferem")]
        public string ConfirmacaoSenha { get; set; }
    }
}