import { useState, useEffect, Ad, randomImagesCars, userAds, fetchAds } from './../../imports.ts'
import "./Ads.scss"

export const Ads = ({ user, refreshAds, toggleMyAds }) => {
    const [ads, setAds] = useState([]);

    useEffect(() => {
        if(toggleMyAds){
            userAds(user.userId).then((ads) => {
            setAds(ads)
          });
        }
        else{
            fetchAds().then((ads) => {
            setAds(ads)
          });
        }
    }, [refreshAds,toggleMyAds]);

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
