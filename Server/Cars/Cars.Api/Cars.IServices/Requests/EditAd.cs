using System;
using Cars.Common.Enums;

namespace Cars.IServices.Requests
{
    public class EditAd
    {
        
        public int CategoryId { get; set; }
        public string TitleAd { get; set; }
        public string DescriptionAd { get; set; }
    }
}