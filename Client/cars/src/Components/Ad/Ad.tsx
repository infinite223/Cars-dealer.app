import { useState, AiOutlineCloseSquare } from './../../imports.ts'
import loupe from './../../icons/loupe.png'
import "./Ad.scss"

export const Ad = ({ adId, title, description, image}) => {
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
          </div>
        </div>
      }
    </>
  )
}
