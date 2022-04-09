using System;
using System.Collections.Generic;
using Cars.Common.Enums;
using Cars.Domain.DomainExceptions;

namespace Cars.Domain.Ad
{
    public class Ad
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreationDate { get; private set; }
        public string TitleAd { get; private set; }
        public string DescriptionAd { get; private set; }
        

        public Ad(int id, int userId,int? categoryId, DateTime creationDate, string titleAd, string descriptionAd)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            CreationDate = creationDate;
            TitleAd = titleAd;
            DescriptionAd = descriptionAd;
        }
        public Ad(int userId, int categoryId, string titleAd, string descriptionAd)
        {
            UserId = userId;
            CategoryId = categoryId;
            TitleAd = titleAd;
            DescriptionAd = descriptionAd;
        }

        public void EditAd(int categoryId, string titleAd, string descriptionAd)
        {
            CategoryId = categoryId;
            TitleAd = titleAd;
            DescriptionAd = descriptionAd;
        }
                public void RemoveAd(int id, int userId,int categoryId, DateTime creationDate, string titleAd, string descriptionAd)
                {
                    Id = id;
                    UserId = userId;
                    CategoryId = categoryId;
                    CreationDate = creationDate;
                    TitleAd = titleAd;
                    DescriptionAd = descriptionAd;
                }
    }
}