import React, { useState } from 'react'
import { AiOutlineCloseSquare } from "react-icons/ai"
import "./Ad.scss"

export const Ad = ({title, description}) => {
  const [toggleFullAd, setToggleFullAd] = useState(false)
  return (
    <>
      <div className='Ad flex' onClick={() =>setToggleFullAd(true)}>
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
      {toggleFullAd &&
        <div className='full__Ad'>
          <AiOutlineCloseSquare size={32} className='exit-icon' onClick={()=>setToggleFullAd(false)}/>
        </div>
      }
    </>
  )
}
