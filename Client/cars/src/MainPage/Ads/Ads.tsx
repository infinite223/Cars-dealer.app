import React, {useState,useEffect} from 'react'
import axios from 'axios'
import { Ad } from '../../Components/Ad/Ad.tsx'

import "./Ads.scss"

export const Ads = () => {
    const [ads, setAds] = useState([]);

    useEffect(() => {
        fetchAds().then((ads) => {
        setAds(ads)
        });
    }, []);

    const fetchAds = async () => {
        const { data: ads } = await axios.get("https://localhost:5001/api/v2/ad/allAds");
        return ads;
    };
    console.log(ads)
  return (
    <div className='Ads-conteiner'>
        {
            ads.map(ad=>{
                return <Ad title={ad.titleAd} description={ad.descriptionAd}/>
            })
        }
    </div>
  )
}
