using System;
using System.Collections.Generic;

namespace Cars.Data.Sql.DAO
{
    public class ObservAd
    {
        public int ObservAdId { get; set; }
        public int UserId { get; set; }
        public int AdId { get; set; }
        public virtual User User { get; set; }
        public virtual Ad Ad { get; set; }
    }
}