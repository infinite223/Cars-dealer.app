using System.Threading.Tasks;
using Cars.IServices.Requests;

namespace Cars.IServices.Ad
{
    public interface IAdService
    {
        Task<Cars.Domain.Ad.Ad> GetAdByAdId(int adId);
       // Task<Cars.Domain.Ad.Ad> GetAllAds();
        Task<Cars.Domain.Ad.Ad> CreateAd(CreateAd createAd);
        Task EditAd(EditAd createAd, int adId);
        Task RemoveAd(int adId);
    }
    
}