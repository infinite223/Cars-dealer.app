using Cars.Common.Enums;
// using Foodly.Data.Sql.Enums;

namespace Cars.Data.Sql.DAO
{
    public class Media
    {
        public int MediaId { get; set; }
        public int AdId { get; set; }
        public MediaType MediaType { get; set; }
        public string MediaHref { get; set; }

        public virtual Ad Ad { get; set; }

    }
}