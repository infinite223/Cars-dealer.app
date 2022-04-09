using Cars.Api.ViewModels;

namespace Cars.Api.Mappers
{
    public class AdToAdViewModelMapper
    {
        public static AdViewModel AdToAdViewModel(Domain.Ad.Ad ad)
        {
            var adViewModel = new AdViewModel
            {
                AdId = ad.Id,
                UserId = ad.UserId,
                CategoryId = ad.CategoryId,
                CreationDate = ad.CreationDate,
                TitleAd = ad.TitleAd,
                DescriptionAd = ad.DescriptionAd
            };
            return adViewModel;
        }   
    }
}