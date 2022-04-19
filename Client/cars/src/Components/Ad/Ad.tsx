import { useState, AiOutlineCloseSquare, removeAd } from './../../imports'
import loupe from './../../icons/loupe.png'
import "./Ad.scss"
import { editAds } from '../../Requests/Requests';

interface Props {
  toggleMyAds:boolean;
  adId:number;
  title:string;
  description:string;
  image:string;
  refreshAds:number;
  setRefreshAds:(React.Dispatch<React.SetStateAction<number>>);
  price:number;
}

export const Ad:React.FC<Props> = ({ toggleMyAds, adId, title, description, image, refreshAds, setRefreshAds, price}) => {
  const [toggleFullAd, setToggleFullAd] = useState(false)
  const [toggleEditAd, setToggleEditAd] = useState(false)

  const [editTitle, setEditTitle] = useState<string>()
  const [editDescription, setEditDescription] = useState<string>()

  const editAd = {
    CategoryId:2,
    RegistrationDate:"22",
    TitleAd:editTitle?editTitle:title,
    DescriptionAd:editDescription?editDescription:description 
  }

  return (
    <>
      <div className='Ad flex' onClick={() =>setToggleFullAd(true)}>
        <div className='Ad-loupe'><img src={loupe} width="80px"/></div>  
        <div className="Ad-id">id: {adId}</div>
          {image ?<img className='Ad-image' src={image}/>:<text className='Ad-no-images flex'>No images</text>}
        <div className='Ad-info'>
          <h3>{title}</h3>
         <text className='text-price'>{price} PLN</text>
        </div>
      </div>
      {toggleFullAd &&
        <div className='full__Ad'>
          <AiOutlineCloseSquare size={32} className='exit-icon' onClick={()=>setToggleFullAd(false)}/>
          <div className='full_Ad-img'>
            <div className="Ad-id">id: {adId}</div>
            <img src={image}/>
          </div>
          <div className='full_Ad-info'>
            {toggleEditAd&&<h3>Edit...</h3>}
            <h3>{toggleEditAd?<input onChange={(e)=>setEditTitle(e.target.value)} defaultValue={title}/>:title}</h3>
            <p>{toggleEditAd?<input style={{width:"200px",fontSize:"13px"}} onChange={(e)=>setEditDescription(e.target.value)} defaultValue={description}/>:description}</p>
            <text>{price} PLN</text>
            {toggleMyAds&&<div className='full_Ad-options flex'>
            <button className='button-edit' onClick={async ()=>(!toggleEditAd?setToggleEditAd(true):setToggleEditAd(false),await editAds(adId, editAd), await setRefreshAds(refreshAds+1))}>Edit</button>
            <button className='button-remove' onClick={async ()=>(await removeAd(adId),await setRefreshAds(refreshAds+1),setToggleFullAd(false))}>Remove Ad</button>
          </div>}
          </div>
        </div>
      }
    </>
  )
}
