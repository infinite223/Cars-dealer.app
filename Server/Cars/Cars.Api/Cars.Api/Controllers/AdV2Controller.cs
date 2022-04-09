
using System.Linq;
using System.Threading.Tasks;
using Cars.Api.Mappers;
using Cars.Api.Validation;
using Cars.Data.Sql;
using Cars.IServices.Ad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars.Api.Controllers
{
    [ApiVersion( "2.0" )]
    [Route( "api/v{version:apiVersion}/ad" )]
    public class AdV2Controller: Controller
    {
        private readonly CarsDbContext _context;
        private readonly IAdService _adService;
        
        public AdV2Controller(CarsDbContext context, IAdService adService)
        {
            _context = context;
            _adService = adService;
        }
        
        [HttpGet("{adId:min(1)}", Name = "GetAdById")]
        public async Task<IActionResult> GetAdByAdId(int adId)
        {
            var ad = await _adService.GetAdByAdId(adId);
            if (ad != null)
            {
                return Ok(AdToAdViewModelMapper.AdToAdViewModel(ad));
            }
            return NotFound();
        }
        [HttpGet("allAds", Name = "GetAllAds")]
        public async Task<IActionResult> GetAds()
        {
            var ads = _context.Ad.Where(x => x.AdId != 0);
            return Ok(ads);
        }
        
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateAd createAd)
        {
            var ad = await _adService.CreateAd(createAd);
            
            return Created(ad.Id.ToString(),AdToAdViewModelMapper.AdToAdViewModel(ad)) ;
        }
        
        
        [ValidateModel]
        [HttpPatch("edit/{adId:min(1)}", Name = "EditAd")]
        public async Task<IActionResult> EditAd([FromBody] IServices.Requests.EditAd editAd, int adId)
        {
            await _adService.EditAd(editAd, adId);
            
            return NoContent();
        }
        
      [HttpDelete("{adId:min(1)}", Name = "RemoveAd")]
      [ValidateModel]
        public async Task<IActionResult> RemoveAd(int adId)
        {
            
           await _adService.RemoveAd(adId);
           return NoContent();
        }
    }
}