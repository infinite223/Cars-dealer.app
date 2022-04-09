import React, { useState } from 'react'
import "./MainPage.scss"
import { MdOutlineArrowBackIos } from "react-icons/md"
import { AnimatePresence, motion, useCycle } from "framer-motion";


import { Ads } from "./Ads/Ads.tsx"
import { NavContent } from "../Components/NavContent/NavContent.tsx"

export const MainPage = () => {
  const [open, cycleOpen] = useCycle(true, false);
  const [statusLogin, setStatusLogin] = useState(false)

  console.log(statusLogin)

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
                      <NavContent statusLogin={statusLogin} setStatusLogin={setStatusLogin}/>
                  </motion.div>             
                </motion.nav>}                    
             </AnimatePresence>

            <div className='content flex'>
                <div className='content__nav'>
                  {!open &&<motion.div className='nav-close' >
                      <MdOutlineArrowBackIos size={25} onClick={cycleOpen}>{open ? "Close" : "Open"}</MdOutlineArrowBackIos>
                   </motion.div>}

                  {statusLogin &&<button onClick={()=>setStatusLogin(false)}>Logout</button>}
                </div>
                <Ads/>
            </div>
    </div>
  )
}
