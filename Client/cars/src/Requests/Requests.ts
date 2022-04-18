import axios from "axios";

interface NewAd {
    UserId:number;
    CategoryId?:number;
    TitleAd?:string;
    DescriptionAd?:string;

}
export const fetchAds = async () => {
    const { data: ads } = await axios.get("https://localhost:5001/api/v2/ad/allAds");
    return ads;
};

export const addAds = async ( newAd:NewAd ) => {
    if(newAd.TitleAd && newAd.TitleAd!==null){
        const { data: ad } = await axios.post("http://localhost:5000/api/v2/ad",newAd);
        return ad!=null?"dodano":"nie udało się dodać";
    }
  };

export const userAds = async ( userId:number ) => {
  if(userId){
    const { data: userAds } = await axios.get(`https://localhost:5001/api/v2/ad/userAds/${userId}`);
    return userAds;
  }
};

export const removeAd = async ( adId:number ) => {
  try{
    const { data: noContent } = await axios.delete(`http://localhost:5000/api/v2/ad/${adId}`);
    return noContent;
  }catch(error){
    return "error";
  }
};

export const loginUser = async (login:string, password:string) => {
  try{
    const { data: user } = await axios.get(`https://localhost:5001/api/v2/user/login/${login}/${password}`);
    return user;
  }catch(error){
    return "error";
  }
};

  export const randomImagesCars = [
    "https://samochody.pl/api/proxy/photo/26800650-3f9a-11eb-bdf1-1f25f7028f1e/cover",
    "https://www.wyborkierowcow.pl/wp-content/uploads/2020/08/opel-astra-cennik-2021-otwarcie.jpg",
    "https://www.gieldaklasykow.pl/wp-content/uploads/2021/07/opel-vectra-c-003-672x372.jpg",
    "https://www.wyborkierowcow.pl/wp-content/uploads/2022/01/Fiat-500e-02.jpg",
    "https://upload.wikimedia.org/wikipedia/commons/8/81/Polski_Fiat_126p_rocznik_1973.jpg",
    "https://ocdn.eu/pulscms-transforms/1/jQ8ktkpTURBXy80Yzc0ODcwMjIxYjlkYjIxOWUzYWQ1ZjY0Y2Q3MjQ4MC5qcGeRlQPNATTNAU_NBpzNA7g",
    "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/VW_Passat_B5.jpg/1200px-VW_Passat_B5.jpg",
    "https://i.wpimg.pl/1920x0/m.autokult.pl/audi-a4-to-c7b33837cde1c592379b2.jpg"
  ]