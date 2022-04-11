import React, {useState,useEffect} from 'react'
import { Ad } from '../../Components/Ad/Ad.tsx'
import { fetchAds } from '../../Requests/Requests.ts'
import { randomImagesCars } from '../../Requests/Requests.ts'

import "./Ads.scss"

export const Ads = ({ refreshAds }) => {
    const [ads, setAds] = useState([]);
    const [imageNumber, setImageNumber] = useState(0)

    useEffect(() => {
        fetchAds().then((ads) => {
        setAds(ads)
        });
    }, []);

  //  [Math.floor(Math.random() * (randomImagesCars.length - 0 + 1)) + 0]}
    function getRandomImage() { 
        setImageNumber(imageNumber+1)   
        if(imageNumber>randomImagesCars.length-1){
            setImageNumber(0)
        }
        return 0
      }

      console.log(ads)
  return (
    <div className='Ads-conteiner'>
        {
            ads.map((ad,i) => {
                return <Ad key={i} adId={ad.adId} image={randomImagesCars[imageNumber<7?i:imageNumber&&setImageNumber(imageNumber+1)]} title={ad.titleAd} description={ad.descriptionAd}/>
            })
        }
    </div>
  )
}
