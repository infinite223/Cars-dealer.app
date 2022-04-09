using System;
using System.Collections.Generic;
using Cars.Common.Enums;

namespace Cars.Data.Sql.DAO
{
    public class User
    {
        public User()
        {
            Ads = new List<Ad>();
            ObservAds = new List<ObservAd>();
        }
        

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int AdsCount { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<ObservAd> ObservAds { get; set; }
    }
}