import axios from "axios";

export const fetchAds = async () => {
    const { data: ads } = await axios.get("https://localhost:5001/api/v2/ad/allAds");
    return ads;
};

export const addAds = async ( newAd ) => {
    const { data: ad } = await axios.post("http://localhost:5000/api/v2/ad",newAd);
    return ad!=null?"dodano":"nie udało się dodać";
  };
