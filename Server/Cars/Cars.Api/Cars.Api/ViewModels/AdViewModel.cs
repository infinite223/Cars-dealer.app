using System;
using Cars.Common.Enums;

namespace Cars.Api.ViewModels
{
    public class AdViewModel
    {
        public int AdId { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public string TitleAd { get; set; }
        public string DescriptionAd { get; set; }
        
    }
}