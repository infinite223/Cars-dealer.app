using System;
using System.Collections.Generic;

namespace Cars.Data.Sql.DAO
{
    public class Category
    {
        public Category()
        {
            Ads = new List<Ad>();
        }
        public int? CategoryId { get; set; }
        public string NameCategory { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
    }
}   