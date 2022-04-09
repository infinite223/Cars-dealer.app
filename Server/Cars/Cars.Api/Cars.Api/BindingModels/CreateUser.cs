using System;
using System.ComponentModel.DataAnnotations;
using Cars.Common.Enums;

namespace Cars.Api.BindingModels
{
    public class CreateUser
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
    }
}