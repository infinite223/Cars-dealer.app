using System;
using Cars.Common.Enums;

namespace Cars.IServices.Requests
{
    public class CreateUser
    {
        public string UserName { get; set; }
        
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}