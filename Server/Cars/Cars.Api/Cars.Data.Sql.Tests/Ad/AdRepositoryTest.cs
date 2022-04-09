using System;
using System.Threading.Tasks;
using Cars.Common.Enums;
using Cars.Data.Sql.Ad;
using Cars.IData.Ad;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Cars.Data.Sql.Tests.Ad
{
    public class AdRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private  CarsDbContext _context;
        private  IAdRepository _adRepository;

        public AdRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarsDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=;port=3306;database=Cars_db;");
            _context = new CarsDbContext(optionsBuilder.Options);
            _adRepository = new AdRepository(_context);
        }
        
        
        [Fact]
        public async Task EditAd_Returns_Correct_Response()
        {
            var ad= await _adRepository.GetAd(1);
            var afterEditAd = await _adRepository.GetAd(1);;
            ad.CategoryId = 4;
            await _adRepository.EditAd(ad);
            
            var editAd = await _context.Ad.FirstOrDefaultAsync(x => x.AdId == 1);
            
            Assert.True(editAd.CategoryId == 2);
            await _adRepository.EditAd(afterEditAd);
            
            await _context.SaveChangesAsync();
        }
        
        [Fact]
        public async Task RemoveAd_Returns_Correct_Response()
        {
            var ad = await _adRepository.GetAd(2);
            await _adRepository.RemoveAd(ad);
            
            Assert.Null(await _context.Ad.FirstOrDefaultAsync(x => x.AdId == 2));
            await _adRepository.AddAd(ad);
            
            await _context.SaveChangesAsync();
        }
    }
}