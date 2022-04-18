import "./MainPage.scss"
import { useState, AnimatePresence, motion, useCycle, MdOutlineArrowBackIos, Ads, NavContent} from "../imports";
import { MouseEventHandler } from "react";

export const MainPage = () => {
  const [open, cycleOpen] = useCycle(true, false);
  const [statusLogin, setStatusLogin] = useState(null)
  const [toggleMyAds, setToggleMyAds] = useState(false)
  const [refreshAds, setRefreshAds] = useState(false)

  return (
    <div className='mainPage'>
            <AnimatePresence>   
              {open &&       
                <motion.nav
                className='flex'
                  initial={{ width: 500 }}
                  animate={{
                    width: 400
                  }}
                  exit={{
                    width: "100px",
                    transition: { delay: 0.1, duration: 0.3 }
                  }}
                >                              
                  <motion.div
                     initial="closed"
                     animate="open"
                     exit="closed"                  
                  >
                      <div className='nav-open' >
                        <MdOutlineArrowBackIos size={25} onClick={cycleOpen}>{open ? "Close" : "Open"}</MdOutlineArrowBackIos>
                      </div>
                      <NavContent refreshAds={refreshAds} setRefreshAds={setRefreshAds} statusLogin={statusLogin} setStatusLogin={setStatusLogin}/>
                  </motion.div>             
                </motion.nav>}                    
             </AnimatePresence>
                  
            <div className='content flex'>
                <div className='content__nav'>               
                  {!open &&<motion.div className='nav-close' >
                      <MdOutlineArrowBackIos size={25} onClick={cycleOpen}>{open ? "Close" : "Open"}</MdOutlineArrowBackIos>
                   </motion.div>}

                  {statusLogin && <div> 
                    <h2>{statusLogin.userName}</h2>
                    <button className="button-ads" onClick={()=>setToggleMyAds(!toggleMyAds)}>{!toggleMyAds?"My ads":"All ads"}</button>
                    <button onClick={()=> (setStatusLogin(null),setToggleMyAds(false))}>Logout</button>
                  </div>}
                </div>
                <Ads user={statusLogin&&statusLogin} toggleMyAds={toggleMyAds} refreshAds={refreshAds} setRefreshAds={setRefreshAds}/>
            </div>
    </div>
  )
}
