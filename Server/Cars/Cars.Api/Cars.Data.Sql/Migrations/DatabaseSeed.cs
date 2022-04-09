using System;
using System.Collections.Generic;
using System.Linq;
using Cars.Common.Enums;
using Cars.Common.Extensions;
using Cars.Data.Sql.DAO;
// using Foodly.Data.Sql.Enums;
// using Foodly.Data.Sql.Extensions;

namespace Cars.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly CarsDbContext _context;
        
        //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
        public DatabaseSeed(CarsDbContext context)
        {
            _context = context;
        }
        
        //metoda odpowiadająca za uzupełnienie utworzonej bazy danych testowymi danymi
        //kolejność wywołania ma niestety znaczenie, ponieważ nie da się utworzyć rekordu
        //w bazie dnaych bez znajmości wartości klucza obcego
        //dlatego należy zacząć od uzupełniania tabel, które nie posiadają kluczy obcych
        //--OFFTOP
        //w przeciwną stronę działa ręczne usuwanie tabel z wypełnionymi danymi w bazie danych
        //należy zacząć od tabel, które posiadają klucze obce, a skończyć na tabelach, które 
        //nie posiadają
        public void Seed()
        {
            //regiony pozwalają na zwinięcie kodu w IDE
            //nie sa dobrą praktyką, kod w danej klasie/metodzie nie powinien wymagać jego zwijania
            //zastosowałem je z lenistwa nie powinno to mieć miejsca 
            #region CreateUsers
            var userList = BuildUserList();
            //dodanie użytkowników do tabeli User
            _context.User.AddRange(userList);
            //zapisanie zmian w bazie danych
            _context.SaveChanges();
            #endregion
            
      #region CreateCategories
            var categoryList = BuildCategoryList();
            _context.Category.AddRange(categoryList);
            _context.SaveChanges();
            #endregion
            
            #region CreateAds
            var adList = BuildAdList(userList, categoryList);
            _context.Ad.AddRange(adList);
            _context.SaveChanges();
            #endregion

            #region CreateObservAds
            var observList = BuildObservAds(userList,adList);
            _context.ObservAd.AddRange(observList);
            _context.SaveChanges();
            #endregion
            

            #region CreateMedias
            var mediaList = BuildMediaList(adList);
            _context.Media.AddRange(mediaList);
            _context.SaveChanges();
            #endregion
            
        }

        private IEnumerable<DAO.User> BuildUserList()
        {
            var userList = new List<DAO.User>();
            var user = new DAO.User()
            {
                UserName = "Dawid",
                Email = "d.saaaa@student.po.edu.pl",
                Login = "test",
                Password = "test",
                RegistrationDate = DateTime.Now.AddYears(-3),
                AdsCount = 0,
            };
            userList.Add(user);

            var user2 = new DAO.User()
            {
                UserName = "Krokodyl",
                Email = "krokodyl@student.po.edu.pl",
                Login = "krokodyl",
                Password = "test1",
                RegistrationDate = DateTime.Now.AddYears(-2),
                AdsCount = 0,
            };
            userList.Add(user2);
            
            for (int i = 3; i <= 20; i++)
            {
                var user3 = new DAO.User
                {
                    UserName = "user" + i,
                    Email = "user" + i + "@student.po.edu.pl",
                    Login = "user"+i,
                    Password = "password",
                    RegistrationDate = DateTime.Now.AddYears(-2),
                    AdsCount = 0,
                };
                userList.Add(user3);
            }

            return userList;
        }
        
      
        private IEnumerable<Category> BuildCategoryList()
        {
            var categoryList = new List<Category>();
            
                var Category1 = new Category()
                {
                    CategoryId = 1,
                    NameCategory = "Sedan",
                };
                categoryList.Add(Category1);
                
                var Category2 = new Category()
                {
                    CategoryId = 2,
                    NameCategory = "kombi",
                };
                categoryList.Add(Category2);
                
                var Category3 = new Category()
                {
                    CategoryId = 3,
                    NameCategory = "hatchback",
                };
                categoryList.Add(Category3);
                
                var Category4 = new Category()
                {
                    CategoryId = 4,
                    NameCategory = "coupé",
                };
                categoryList.Add(Category4);
                
                var Category5 = new Category()
                {
                    CategoryId = 5,
                    NameCategory = "SUV",
                };
                categoryList.Add(Category5);
            
            return categoryList;
        }
        
        private IEnumerable<DAO.Ad> BuildAdList(IEnumerable<DAO.User> userList, IEnumerable<Category> categoryList)
        {
            var adList = new List<DAO.Ad>();

                var rnd = new Random();
                foreach (var user in userList)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        adList.Add(new DAO.Ad
                        {
                            UserId =i,
                            CategoryId = rnd.Next(1, 5),
                            CreationDate = DateTime.Now,
                            TitleAd = "Ford" + i,
                            DescriptionAd = "Super autko, polecam :)" + i,
                        });
                    }
                }
                
                return adList;
        }

        private IEnumerable<ObservAd> BuildObservAds(
            IEnumerable<DAO.User> userList,IEnumerable<DAO.Ad> adList)
        {
            var observAdsList = new List<ObservAd>();
           
            foreach (var ad in adList)
            {
                for (int i = 1; i <= 20; i++)
                {
                    observAdsList.Add(new ObservAd
                    {
                        UserId =  ad.UserId,
                        AdId = adList.First().AdId,
                    });
                }
            }
            
            return observAdsList;
        }

        private IEnumerable<Media> BuildMediaList(
            IEnumerable<DAO.Ad> adList)
        {
            var medias = new Dictionary<int,Func<List<(string,MediaType)>>>
            {
                [6]=()=>new List<(string, MediaType)>
                {
                    ("https://www.rickbayless.com/wp-content/uploads/2014/02/ChipsAndGuac.jpg"
                        ,MediaType.Image),
                    ("https://www.tablespoon.com/-/media/Images/recipe-hero/appetizer/mini-spinach-lasagna-roll-ups_hero.jpg",
                        MediaType.Image),
                    ("https://diy-enthusiasts.com/wp-content/uploads/2013/08/fun-appetizers-snacks-kids-party-muffin-cars-600x400.jpg",
                        MediaType.Image),
                    ("https://img1.cookinglight.timeinc.net/sites/default/files/styles/4_3_horizontal_-_1200x900/public/image/2016/04/main/1605p35-bbq-shrimp-toasts.jpg?itok=syp7ZxSt",
                        MediaType.Image),
                    ("https://search.chow.com/thumbnail/840/517/www.chowstatic.com/assets/2015/10/31604_Goat_cheese_stuffed_peppadews_2.jpg",
                        MediaType.Image)
                },
                [0]=()=>new List<(string, MediaType)>
                {
                    ("https://www.riverwalkbarandgrill.com/wp-content/uploads/bfi_thumb/Riverwalk-Bar-and-Grill-Breakfast-Menu-1920x800-mcpcbb43b6zb3i1vhbzguroermkgt6dse3rfnmn1vk.jpg",
                        MediaType.Image),
                    ("https://cdn3.tmbi.com/secure/RMS/attachments/37/300x300/Buttermilk-Buckwheat-Pancakes_EXPS_BBBZ16_25056_05B_26_2b.jpg",
                        MediaType.Image),
                    ("https://www.kingscross.co.uk/media/P_KXC_L1_DEV_001_Spiritland_N3-800x800.jpg",
                        MediaType.Image),
                    ("https://www.firstwatch.com/wp-content/uploads/2016/12/avacadoToast.jpg",
                        MediaType.Image),
                    ("https://www.youtube.com/watch?v=b6eWM2bJ8cY",
                        MediaType.Video),
                    ("https://www.stylemotivation.com/wp-content/uploads/2014/03/20-Great-Breakfast-Brunch-Recipes-3.jpg",
                        MediaType.Image)
                },
                [1]=()=>new List<(string, MediaType)>
                {
                    ("https://s3.amazonaws.com/video-api-prod/assets/71c4d5d0cf3e468c825945fa82d1eb37/Untitled-1.jpg",
                        MediaType.Image),
                    ("https://www.seriouseats.com/2018/01/20180116-cranachan-vicky-wasik-1-3-625x469.jpg",
                        MediaType.Image),
                    ("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR9L4VciYjhLqEvgva0w-vd1HM416FHERafk3is2nul5r9kM_UH",
                        MediaType.Image)
                },
                [2]=()=>new List<(string, MediaType)>
                {
                    ("https://www.tasteofhome.com/wp-content/uploads/2017/08/Asparagus-Ham-Dinner_EXPS_THAM17_14208_B11_08_5b-9.jpg",
                        MediaType.Image),
                    ("https://www.cscassets.com/ca/recipes/medium/medium_757.jpg",
                        MediaType.Image),
                    ("https://greatist.com/sites/default/files/7%20Super%20Easy%20Dinners.jpg",
                        MediaType.Image),
                    ("https://static-communitytable.parade.com/wp-content/uploads/2015/12/shared-20.jpg",
                        MediaType.Image),
                    ("https://www.youtube.com/watch?v=dfR_LdA3fPI",
                        MediaType.Image),
                    ("https://www.youtube.com/watch?v=spHmQb5mA5E",
                        MediaType.Image),
                },
                [3]=()=>new List<(string, MediaType)>
                {
                    ("https://img.grouponcdn.com/deal/4GYhYBECmcfjVwYCozmSSaUSRvDK/4G-700x420/v1/c700x420.jpg",
                        MediaType.Image),
                    ("https://www.littlethings.com/app/uploads/2017/03/recipe_card_MakeAheadSmoothies-850x416.jpg",
                        MediaType.Image),
                    ("https://anilakalleshi.com/wp-content/uploads/2018/02/Smoothies-combine-colorful-ingredients.jpg",
                        MediaType.Image),
                    ("https://cdn.shopify.com/s/files/1/0795/1583/products/classic-cleanse-family-shot.jpg?v=1515191340",
                        MediaType.Image)
                },
                [4]=()=>new List<(string, MediaType)>
                {
                    ("https://www.bbcgoodfood.com/sites/default/files/styles/category_retina/public/recipe-collections/collection-image/2017/06/under-200-calorie-collection-pea-shakshuka.jpg?itok=MxK__bZp",
                        MediaType.Image),
                    ("https://www.exploringhealthyfoods.com/wp-content/uploads/2016/10/Lean-Healthy-Meal-Idea-Vegan.jpg",
                        MediaType.Image),
                    ("https://images.media-allrecipes.com/images/65978.jpg",
                        MediaType.Image),
                    ("https://cdn2.momjunction.com/wp-content/uploads/2014/12/Green-Magic.jpg",
                        MediaType.Image)
                },
                [5]=()=>new List<(string, MediaType)>
                {
                    ("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQv9g3XUnY7HabOD75syK8SKR9H3lC2PXDBGwtfFOEbhzfPN309",
                        MediaType.Image),
                    ("https://minimalistbaker.com/wp-content/uploads/2015/08/AMAZING-HEALTHY-Vegan-Fried-Rice-with-Crispy-Tofu-vegan-glutenfree-recipe-chinese-friedrice-minimalistbaker-plantbased.jpg",
                        MediaType.Image),
                    ("https://imagesvc.timeincapp.com/v3/mm/image?url=http%3A%2F%2Fimg1.cookinglight.timeinc.net%2Fsites%2Fdefault%2Ffiles%2Fstyles%2F4_3_horizontal_-_1200x900%2Fpublic%2Fimage%2F2017%2F03%2Fmain%2Fbeer-brushed-tofu-skewers-barley-1705p105.jpg%3Fitok%3DOdHLIfLx&w=700&q=85",
                        MediaType.Image)
                },
            };
            var rand = new Random();
            var mediaList = new List<Media>();
            int j = 0;
            foreach (var ad in adList)
            {   
                var media = medias[j]();
                if (j == 5) j = 0;j++;
                media.Shuffle();

                //var range = rand.Next(1, 4);
               // for (int i = 0; i < range; i++)
                {
                    mediaList.Add(new Media
                    {
                        AdId = ad.AdId,
                        MediaHref = media[1].Item1,
                        MediaType = media[2].Item2
                    });
                }                
            }

            return mediaList;
        }
    }

}