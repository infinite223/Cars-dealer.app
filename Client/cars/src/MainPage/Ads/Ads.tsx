import React, {useState,useEffect} from 'react'
import axios from 'axios'
import { Ad } from '../../Components/Ad/Ad.tsx'
import { fetchAds } from '../../Requests/Requests.ts'

import "./Ads.scss"

export const Ads = ({ refreshAds }) => {
    const [ads, setAds] = useState([]);

    useEffect(() => {
        fetchAds().then((ads) => {
        setAds(ads)
        });
    }, [refreshAds]);

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
