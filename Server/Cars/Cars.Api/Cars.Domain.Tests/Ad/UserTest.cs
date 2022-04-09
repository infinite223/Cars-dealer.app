using System;
using Cars.Common.Enums;
using Cars.Domain.DomainExceptions;
using Xunit;

namespace Cars.Domain.Tests.Ad
{
    public class AdTest
    {
        public AdTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void CreateAd_Returns_Correct_Response()
        {
            var ad = new Domain.Ad.Ad(1,1, "Audi A3", "Tanio sprzedam");
            
            Assert.Equal(1, ad.UserId);
            Assert.Equal(1, ad.CategoryId);
            Assert.Equal("Audi A3", ad.TitleAd);
            Assert.Equal("Tanio sprzedam", ad.DescriptionAd);
        }
        [Fact]
        public void CreateAd_Returns_InCorrect_Response()
        {
            var ad = new Domain.Ad.Ad(2,3, "BMW M3", "trup w dobrej cenie");
            
            Assert.NotEqual(10, ad.UserId);
            Assert.NotEqual(20, ad.CategoryId);
            Assert.Equal("BMW M3", ad.TitleAd);
            Assert.Equal("trup w dobrej cenie", ad.DescriptionAd);
        }

    }
}