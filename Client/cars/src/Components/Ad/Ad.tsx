import { useState, AiOutlineCloseSquare, removeAd } from './../../imports.ts'
import loupe from './../../icons/loupe.png'
import "./Ad.scss"

export const Ad = ({ toggleMyAds, adId, title, description, image, refreshAds, setRefreshAds}) => {
  const [toggleFullAd, setToggleFullAd] = useState(false)

  return (
    <>
      <div className='Ad flex' onClick={() =>setToggleFullAd(true)}>
        <div className='Ad-loupe'><img src={loupe} width="80px"/></div>  
        <div className="Ad-id">id: {adId}</div>
          {image ?<img className='Ad-image' src={image}/>:<text className='Ad-no-images flex'>No images</text>}
        <div className='Ad-info'>
          <h3>{title}</h3>
         <text className='text-price'>{Math.floor(Math.random() * (100000 - 10000 + 1)) + 10000} PLN</text>
        </div>
      </div>
      {toggleFullAd &&
        <div className='full__Ad'>
          <AiOutlineCloseSquare size={32} className='exit-icon' onClick={()=>setToggleFullAd(false)}/>
          <div className='full_Ad-img'>
            <img src={image}/>
          </div>
          <div className='full_Ad-info'>
            <h3>{title}</h3>
            <p>{description}</p>
            {toggleMyAds&&<div className='full_Ad-options flex'>
            <button className='button-edit'>Edit</button>
            <button className='button-remove' onClick={()=>(removeAd(adId),setRefreshAds(!refreshAds),setToggleFullAd(false))}>Remove Ad</button>
          </div>}
          </div>
        </div>
      }
    </>
  )
}
