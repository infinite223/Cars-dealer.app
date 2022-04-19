import axios from "axios";

interface NewAd {
    AdId?:number;
    UserId?:number;
    CategoryId?:number;
    TitleAd?:string;
    DescriptionAd?:string;
}

export const fetchAds = async () => {
    const { data: ads } = await axios.get("https://localhost:5001/api/v2/ad/allAds");
    return ads;
};

export const fetchMedias = async () => {
  const { data: medias } = await axios.get("https://localhost:5001/api/v2/ad/allMedias");
  return medias;
};

export const addAds = async ( newAd:NewAd ) => {
    if(newAd.TitleAd && newAd.TitleAd!==null){
        const { data: ad } = await axios.post("http://localhost:5000/api/v2/ad",newAd);
        return ad!=null?"dodano":"nie udało się dodać";
    }
};

export const editAds = async ( AdId:number,editAd:NewAd ) => {
  if(editAd.TitleAd && editAd.TitleAd!==null){
      const { data: ad } = await axios.patch(`http://localhost:5000/api/v2/ad/edit/${AdId}`,editAd);
      return ad!=null?"zminiono":"nie udało się zedytować";
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