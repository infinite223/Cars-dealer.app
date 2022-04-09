using System;
using Cars.Common.Enums;

namespace Cars.Api.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int AdsCount { get; set; }
        
    }
}