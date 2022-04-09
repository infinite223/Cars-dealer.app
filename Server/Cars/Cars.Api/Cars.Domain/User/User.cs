using System;
using Cars.Common.Enums;
using Cars.Domain.DomainExceptions;

namespace Cars.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int AdsCount { get; private set; }
        
        public User(int id, string userName, string email,string login, string password, DateTime creationDate, int adsCount)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Login = login;
            Password = password;
            CreationDate = creationDate;
            AdsCount = adsCount;
        }
        public User(string userName, string email, string login, string password)
        {
            UserName = userName;
            Email = email;
            Login = login;
            Password = password;
            CreationDate = DateTime.UtcNow;
            AdsCount = 0;
        }
        
        public void EditUser(string userName, string email, string login, string password)
        {
            UserName = userName;
            Email = email;
            Login = login;
            Password = password;
        }
    }
}