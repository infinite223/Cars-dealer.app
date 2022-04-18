import { useState, useEffect, Ad, randomImagesCars, userAds, fetchAds } from './../../imports'
import "./Ads.scss"

interface Props {
  user : {
    userId: number;
  };
  refreshAds:boolean;
  setRefreshAds:boolean;
  toggleMyAds:boolean;
}

export const Ads: React.FC<Props> = ({ user, refreshAds, setRefreshAds, toggleMyAds }) => {
    const [ads, setAds] = useState([]);

    useEffect(() => {
        if(toggleMyAds){
            userAds(user.userId).then((ads:any) => {
            setAds(ads)
          });
        }
        else{
            fetchAds().then((ads:any) => {
            setAds(ads)
          });
        }
    }, [refreshAds,toggleMyAds]);

  return (
    <div className='Ads-conteiner'>
        {
            ads.map((ad:any,i:number) => {
                return <Ad 
                  key={i} 
                  refreshAds={refreshAds} 
                  setRefreshAds={setRefreshAds}
                  toggleMyAds={toggleMyAds} 
                  adId={ad.adId}
                  image={randomImagesCars[i+1]}
                  title={ad.titleAd}
                  description={ad.descriptionAd}/>
            })
        }
    </div>
  )
}
