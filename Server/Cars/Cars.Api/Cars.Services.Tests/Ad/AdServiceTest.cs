using System;
using System.Threading.Tasks;
using Cars.Common.Enums;
using Cars.Domain.DomainExceptions;
using Cars.IData.Ad;
using Cars.IServices.Requests;
using Cars.IServices.Ad;
using Cars.Services.Ad;
using Moq;
using Xunit;

namespace Cars.Services.Tests.User
{
    public class AdServiceTest
    {
        private readonly IAdService _adService;
        private readonly Mock<IAdRepository> _adRepositoryMock;
        
        public AdServiceTest()
        {
            _adRepositoryMock = new Mock<IAdRepository>();
            _adService = new AdService(_adRepositoryMock.Object);
        }
        
        [Fact]
        public async Task CreateAd_Returns_Correct_Response()
        {
            var ad = new CreateAd
            {
                UserId = 1,
                CategoryId = 1,
                TitleAd = "Ford Mustang",
                DescriptionAd = "nie polecam w sumie xD, dużo pali :("
            };
            
            int expectedResult = 0;
            _adRepositoryMock.Setup(x => x.AddAd
                (new Domain.Ad.Ad
                (
                    ad.UserId,
                    ad.CategoryId,
                    ad.TitleAd,
                    ad.DescriptionAd
                    )))
                .Returns(Task.FromResult(expectedResult));
            
            //Act
            var result = await _adService.CreateAd(ad);

            //Assert
            Assert.IsType<Domain.Ad.Ad>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Id);
        }
    }
}