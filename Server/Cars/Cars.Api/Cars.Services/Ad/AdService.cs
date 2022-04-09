using System;
using System.Threading.Tasks;
using Cars.IData.Ad;
using Cars.IServices.Requests;
using Cars.IServices.Ad;

namespace Cars.Services.Ad
{
    public class AdService: IAdService
    {
        private readonly IAdRepository _adRepository;

        public AdService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public Task<Domain.Ad.Ad> GetAdByAdId(int adId)
        {
            return _adRepository.GetAd(adId);
        }
        /*public Task<Domain.Ad.Ad> GetAllAds()
        {
            return _adRepository.GetAds();
        }*/
        
        public async Task<Domain.Ad.Ad> CreateAd(CreateAd createAd)
        {
            var ad = new Domain.Ad.Ad(createAd.UserId, createAd.CategoryId,createAd.TitleAd, createAd.DescriptionAd);
            ad.Id = await _adRepository.AddAd(ad);  
            return ad;
        }

        public async Task EditAd(EditAd createAd, int adId)
        {
            var ad = await _adRepository.GetAd(adId);
            ad.EditAd(createAd.CategoryId, createAd.TitleAd, createAd.DescriptionAd);
            await _adRepository.EditAd(ad);
        }
        
        public async Task RemoveAd(int adId)
        {
            var ad = await _adRepository.GetAd(adId);
            await _adRepository.RemoveAd(ad);
        }
    }

}