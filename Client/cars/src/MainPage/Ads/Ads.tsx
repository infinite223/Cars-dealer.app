import React, {useState,useEffect} from 'react'
import { Ad } from '../../Components/Ad/Ad.tsx'
import { fetchAds } from '../../Requests/Requests.ts'
import { userAds } from '../../Requests/Requests.ts' 
import { randomImagesCars } from '../../Requests/Requests.ts'

import "./Ads.scss"

export const Ads = ({ refreshAds }) => {
    const [ads, setAds] = useState([]);
    const [imageNumber, setImageNumber] = useState(0)

    useEffect(() => {
        //fetchAds().then((ads) => {
            userAds(2).then((ads) => {
        setAds(ads)
        });
    }, []);

  return (
    <div className='Ads-conteiner'>
        {
            ads.map((ad,i) => {
                return <Ad key={i} adId={ad.adId} image={randomImagesCars[i+1]} title={ad.titleAd} description={ad.descriptionAd}/>
            })
        }
    </div>
  )
}
