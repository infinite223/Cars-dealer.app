using System.Threading.Tasks;

namespace Cars.IData.Ad
{
    public interface IAdRepository
    {
        Task<int> AddAd(Cars.Domain.Ad.Ad ad);
        Task<Cars.Domain.Ad.Ad> GetAd(int adId);
       // Task<Cars.Domain.Ad.Ad> GetAds();
        Task EditAd(Domain.Ad.Ad ad);
        Task RemoveAd(Domain.Ad.Ad ad);
    }
}   