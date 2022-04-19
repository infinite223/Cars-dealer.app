import { useState, addAds, loginUser } from './../../imports'
import './NavContent.scss'

interface StatusLogin {
  userId:number;
  userName:string;
  email?:string;
  login:string;
  password:string;
}


interface Props {
  statusLogin:StatusLogin | null;
  setStatusLogin:(React.Dispatch<React.SetStateAction<StatusLogin | null>>);
  refreshAds:number;
  setRefreshAds:(React.Dispatch<React.SetStateAction<number>>);
}

export const NavContent:React.FC<Props> = ({ refreshAds, setRefreshAds, statusLogin, setStatusLogin }) => {

  const [login, setLogin] = useState("")
  const [password, setPassword] = useState("")
  const [errorLogin, setErrorLogin] = useState("")

  const [model, setModel] = useState("")
  const [category, setCategory] = useState(Number)
  const [description, setDescription] = useState("")

  const newAd = {
    "UserId":statusLogin?statusLogin.userId:1,
    "CategoryId":category,
    "TitleAd":model,
    "DescriptionAd":description
  }

  const userStatus = async (event:any) =>{
    event.preventDefault();
    const user = await loginUser(login, password)
    if(user!=="error" && user){
      setStatusLogin(user);
      setErrorLogin("")
    }
    else{
      setErrorLogin("Nieprawidłowe dane")
    }
  }
  
  return (
    <div className='nav__content flex'>
        { !statusLogin ? <>
          <h2>Cars.<br /> dealer</h2>
          <hr />
          <p>Zaloguj się by móc dodawać swoje ogłoszenia</p>
          <input type="text" placeholder='Login' onChange={(x)=>setLogin(x.target.value)}/>
          <input type="password" placeholder='Password' onChange={(x)=>setPassword(x.target.value)}/>
          <text style={{color:"red"}}>{errorLogin}</text>
          <button onClick={(e)=>userStatus(e)}> Login </button>
        </>:<>
          <h2>Dodaj <br />ogłoszenie</h2>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing</p>
          <input type="text" onChange={(x)=>setModel(x.target.value)} placeholder='Model' style={{width:"77%"}}/>
          <select value={category} onChange={(e)=>setCategory(parseInt(e.target.value,10))} name="Category" >
                <option>Kategoria</option>
                <option value={1}>1. Sedan</option>
                <option value={2}>2. Combi</option>
                <option value={3}>3. hatchback</option>
                <option value={4}>4. Coupe</option>
                <option value={5}>5. SUV</option> 
           </select>
          <textarea  placeholder='Opis' onChange={(x)=>setDescription(x.target.value)}/>
          <button onClick={async ()=>(await addAds(newAd), await setRefreshAds(refreshAds+1))}> Dodaj </button>    
        </> 
        }        
    </div>
  )
}
