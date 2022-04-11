import React, { useState } from 'react'
import { AiOutlineCloseSquare } from "react-icons/ai"
import "./Ad.scss"
import { randomImagesCars } from '../../Requests/Requests.ts'

export const Ad = ({ adId, title, description, image}) => {
  const [toggleFullAd, setToggleFullAd] = useState(false)

  return (
    <>
      <div className='Ad flex' onClick={() =>setToggleFullAd(true)}>
        <div className="Ad-id">id: {adId}</div>
        <img className='Ad-image' src={image}/>
        <div className='Ad-info'>
          <h3>{title}</h3>
          <text>price:<text className='text-price'>40 000 PLN</text></text>
        </div>
      </div>
      {toggleFullAd &&
        <div className='full__Ad'>
          <AiOutlineCloseSquare size={32} className='exit-icon' onClick={()=>setToggleFullAd(false)}/>
          <h3>{title}</h3>
        <p>{description}</p>
        </div>
      }
    </>
  )
}
