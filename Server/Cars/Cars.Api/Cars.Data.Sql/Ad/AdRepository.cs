using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cars.IData.Ad;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data.Sql.Ad
{
    public class AdRepository: IAdRepository
    {
        private readonly CarsDbContext _context;

        public AdRepository(CarsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAd(Domain.Ad.Ad ad)
        {
            var adDao =  new DAO.Ad {
                UserId = ad.UserId,
                CategoryId = ad.CategoryId,
                CreationDate = DateTime.Now,
                TitleAd = ad.TitleAd,
                DescriptionAd = ad.DescriptionAd
            };
            await _context.AddAsync(adDao);
            await _context.SaveChangesAsync();
            return adDao.AdId;
        }

        public async Task<Domain.Ad.Ad> GetAd(int adId)
        {
            var ad = await _context.Ad.FirstOrDefaultAsync(x=>x.AdId==adId);
            
            return new Domain.Ad.Ad(
                ad.AdId,
                ad.UserId,
                ad.CategoryId,
                DateTime.Now,
                ad.TitleAd,
                ad.DescriptionAd
            );

        }
        /*public async Task<Domain.Ad.Ad> GetAds()
        {
            var ads = await _context.Ad.ToListAsync();

           // return ads;
            return new Domain.Ad.Ad(
                ads
            );

        }*/

        public async Task EditAd(Domain.Ad.Ad ad)
        {
            var editAd = await _context.Ad.FirstOrDefaultAsync(x=>x.AdId == ad.Id);
            editAd.CategoryId = ad.CategoryId;
            editAd.TitleAd = ad.TitleAd;
            editAd.DescriptionAd = ad.DescriptionAd;
            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveAd(Domain.Ad.Ad ad)
        {
            var outWhile = true; 
            do
            {
                var removeObservAd = await _context.ObservAd.FirstOrDefaultAsync(n=>n.AdId==ad.Id);
                if (removeObservAd != null)
                {
                    _context.ObservAd.Remove(removeObservAd);
                }
                else
                {
                    outWhile = false;
                }
                await _context.SaveChangesAsync();
            } while (outWhile);
            
            var removeMediaAd = await _context.Media.FirstOrDefaultAsync(n=>n.AdId==ad.Id);
            if (removeMediaAd != null)
            {
                _context.Media.Remove(removeMediaAd); 
            }
            var removeAd = await _context.Ad.FirstOrDefaultAsync(n=>n.AdId==ad.Id);
            if (removeAd != null)
            {
                _context.Ad.Remove(removeAd); 
            }
            
           await _context.SaveChangesAsync();
        }
    }
}