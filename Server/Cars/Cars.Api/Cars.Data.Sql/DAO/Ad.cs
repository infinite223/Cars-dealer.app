using System;
using System.Collections.Generic;
using Cars.Common.Enums;

namespace Cars.Data.Sql.DAO
{
    public class Ad
    {
        public Ad()
        {
            Medias = new List<Media>();
            ObservAd = new List<ObservAd>();
        }
        
        public int AdId { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public string TitleAd { get; set; }
        public string DescriptionAd { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection <ObservAd> ObservAd { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
        public virtual Category Category{ get; set; }
    }
}