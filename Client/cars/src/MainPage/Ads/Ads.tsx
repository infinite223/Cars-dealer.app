import { useState, useEffect, Ad, userAds, fetchAds, fetchMedias } from './../../imports'
import "./Ads.scss"

interface Props {
  user : {
    userId: number;
  } | null;
  refreshAds:number;
  setRefreshAds: (React.Dispatch<React.SetStateAction<number>>);
  toggleMyAds:boolean;
}

interface Ad {
  adId:number;
  titleAd:string;
  descriptionAd:string;
}

export const Ads: React.FC<Props> = ({ user, refreshAds, setRefreshAds, toggleMyAds }) => {
    const [ads, setAds] = useState<Ad | any>([]);
    const [medias, setMedias] = useState<any>([]);

    useEffect(() => {
        if(user && toggleMyAds){
            userAds(user.userId).then((ads:Ad) => {
            setAds(ads)
          });
        }
        else{
            fetchAds().then((ads:Ad) => {
            setAds(ads)
          });
        }      
    }, [refreshAds,toggleMyAds]);

    useEffect(() => {
      fetchMedias().then((medias:any)=>{
        setMedias(medias)
      }) 
  }, []);

  return (
    <div className='Ads-conteiner'  >
        {
            ads.map((ad:Ad,i:number) => {              
                const foundMedia = medias.find((media:any)=>media.adId===ad.adId)             
                return <Ad 
                  key={i} 
                  refreshAds={refreshAds} 
                  setRefreshAds={setRefreshAds}
                  toggleMyAds={toggleMyAds} 
                  adId={ad.adId}
                  image={foundMedia&&foundMedia.mediaHref}
                  title={ad.titleAd}
                  description={ad.descriptionAd}
                  price={Math.floor(Math.random() * (100000 - 10000 + 1)) + 10000} 
                />
            })
        }
    </div>
  )
}
