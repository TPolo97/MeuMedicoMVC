﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuMedico.ViewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}