using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Cars.Common.Enums;

namespace Cars.Api.BindingModels
{
    public class EditUser
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}