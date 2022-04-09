import React from 'react'
import './NavContent.scss'

export const NavContent = ({ statusLogin, setStatusLogin }) => {

  return (
    <div className='nav__content flex'>
        { !statusLogin ? <>
          <h2>Cars.<br /> dealer</h2>
          <hr />
          <p>Zaloguj się by móc dodawać swoje ogłoszenia</p>
          <input type="text" placeholder='Login'/>
          <input type="password" placeholder='Password'/>
          <button onClick={()=>setStatusLogin(true)}> Login </button>
        </>:<>
          <h2>Dodaj <br />ogłoszenie</h2>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing</p>
          <input type="text" placeholder='Model' style={{width:"77%"}}/>
          <select name="Category">
                <option>Kategoria</option>
                <option>1. Sedan</option>
                <option>2. Combi</option>
                <option>3. hatchback</option>
                <option>4. Coupe</option>
                <option>5. SUV</option>
           </select>
          <textarea  placeholder='Opis'/>
          <button onClick={()=>setStatusLogin(true)}> Dodaj </button>    
        </> 
        }
        
    </div>
  )
}
