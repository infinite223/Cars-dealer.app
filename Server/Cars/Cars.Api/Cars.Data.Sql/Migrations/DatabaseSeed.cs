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
                    ("https://i.wpimg.pl/1920x0/m.autokult.pl/audi-a4-to-c7b33837cde1c592379b2.jpg"
                        ,MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/VW_Passat_B5.jpg/1200px-VW_Passat_B5.jpg",
                        MediaType.Image),
                    ("https://samochody.pl/api/proxy/photo/26800650-3f9a-11eb-bdf1-1f25f7028f1e/cover",
                        MediaType.Image),
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2020/08/opel-astra-cennik-2021-otwarcie.jpg",
                        MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/8/81/Polski_Fiat_126p_rocznik_1973.jpg",
                        MediaType.Image)
                },
                [0]=()=>new List<(string, MediaType)>
                {
                    ("https://img.wprost.pl/img/peugeot-208/a1/3c/041627c4fa8def4fe0770181d6a7.jpeg",
                        MediaType.Image),
                    ("https://otoklasyki.pl/Upload/posters/audi-100-avant-c4-1618859021114.jpg",
                        MediaType.Image),
                    ("https://i.wpimg.pl/600x0/m.autokult.pl/mercedes-benz-w210-front-2f27139.jpg",
                        MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/4/44/Mercedes_W210_front_20080320.jpg",
                        MediaType.Image),
                    ("https://motohigh.pl/wp-content/uploads/2020/08/Screenshot_11.jpg",
                        MediaType.Video),
                    ("https://maxtondesign.pl/pol_pl_Dokladki-Progow-BMW-3-E46-Coupe-Cabrio-Generation-V-115_1.jpg",
                        MediaType.Image)
                },
                [1]=()=>new List<(string, MediaType)>
                {
                    ("https://img.wprost.pl/img/peugeot-208/a1/3c/041627c4fa8def4fe0770181d6a7.jpeg",
                        MediaType.Image),
                    ("https://otoklasyki.pl/Upload/posters/audi-100-avant-c4-1618859021114.jpg",
                        MediaType.Image),
                    ("https://i.wpimg.pl/600x0/m.autokult.pl/mercedes-benz-w210-front-2f27139.jpg",
                        MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/4/44/Mercedes_W210_front_20080320.jpg",
                        MediaType.Image),
                    ("https://motohigh.pl/wp-content/uploads/2020/08/Screenshot_11.jpg",
                        MediaType.Video),
                    ("https://maxtondesign.pl/pol_pl_Dokladki-Progow-BMW-3-E46-Coupe-Cabrio-Generation-V-115_1.jpg",
                        MediaType.Image)
                },
                [2]=()=>new List<(string, MediaType)>
                {
                    ("https://i.wpimg.pl/1920x0/m.autokult.pl/audi-a4-to-c7b33837cde1c592379b2.jpg"
                        ,MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/VW_Passat_B5.jpg/1200px-VW_Passat_B5.jpg",
                        MediaType.Image),
                    ("https://samochody.pl/api/proxy/photo/26800650-3f9a-11eb-bdf1-1f25f7028f1e/cover",
                        MediaType.Image),
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2020/08/opel-astra-cennik-2021-otwarcie.jpg",
                        MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/8/81/Polski_Fiat_126p_rocznik_1973.jpg",
                        MediaType.Image)
                },
                [3]=()=>new List<(string, MediaType)>
                {
                    ("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1k8f-n2t0WsCduKxnY-uPGS0lQxsRKYS6ZbcefTAAX4jjAjLqL2cXYAE6-iUHt-o8fzM&usqp=CAU",
                        MediaType.Image),
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2021/02/hyundai-i30n-cennik-2022-otwarcie.jpg",
                        MediaType.Image),
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2020/08/Seat-Altea-21.jpg",
                        MediaType.Image),
                    ("https://motopedia.otomoto.pl/wp-content/uploads/2021/01/GettyImages-1189938625-848x500.jpg",
                        MediaType.Image)
                },
                [4]=()=>new List<(string, MediaType)>
                {
                    ("https://i.wpimg.pl/1920x0/m.autokult.pl/audi-a4-to-c7b33837cde1c592379b2.jpg"
                        ,MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/VW_Passat_B5.jpg/1200px-VW_Passat_B5.jpg",
                        MediaType.Image),
                    ("https://samochody.pl/api/proxy/photo/26800650-3f9a-11eb-bdf1-1f25f7028f1e/cover",
                        MediaType.Image),
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2020/08/opel-astra-cennik-2021-otwarcie.jpg",
                        MediaType.Image),
                    ("https://upload.wikimedia.org/wikipedia/commons/8/81/Polski_Fiat_126p_rocznik_1973.jpg",
                        MediaType.Image)
                },
                [5]=()=>new List<(string, MediaType)>
                {
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2021/02/hyundai-i30n-cennik-2022-otwarcie.jpg",
                        MediaType.Image),
                    ("https://www.wyborkierowcow.pl/wp-content/uploads/2020/08/Seat-Altea-21.jpg",
                        MediaType.Image),
                    ("https://motopedia.otomoto.pl/wp-content/uploads/2021/01/GettyImages-1189938625-848x500.jpg",
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