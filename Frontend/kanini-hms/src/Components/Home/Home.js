import { useState } from 'react';
import Header from './Header/Header';
import HomeContent from './Home Content/HomeContent';
import './Home.css'
import Login from './Login/Login';
import PatientRegister from './PatientRegister/PatientRegister';
import DoctorRegister from './DoctorRegister/DoctorRegister';
import { Link, Route, Routes } from 'react-router-dom';
import AboutUs from './AboutUs/AbooutUs';
import Register from './Register/Register';
import Pending from '../Main/Pending/Pendind';
import Rejected from '../Main/Rejected/Rejected';

function Home()
{
    const [hamburger,setHamburger] = useState(false);
    const toggle=()=>
    {
        if(!hamburger)
            document.body.getElementsByClassName('header-link')[0].classList.add('show');
        else    
            document.body.getElementsByClassName('header-link')[0].classList.remove('show');
        setHamburger(!hamburger);

    }
    const closeMenu = () => {
        document.body.getElementsByClassName('header-link')[0].classList.remove('show');
        setHamburger(false);
      };
   

    return(
        <div className="home">
                <div className='home-header'>
                    <nav>
                        <label className='header-title'>
                            <Link  className='logo' to='/' >KANINI HMS</Link> 
                        </label>
                        <label className='hamburger'>
                            
                        </label>
                        <ul className='header-link'>
                            <li className='header-link-item'> <Link onClick={closeMenu} to='/home/login'>Login</Link> </li>
                            <li className='header-link-item'> <Link onClick={closeMenu} to='/home/Register'>Register</Link> </li>
                            <li className='header-link-item'>  <Link to='/home/AboutUs'  onClick={closeMenu}>About us</Link> </li>
                        </ul>
                        <button className='hamburger' onClick={toggle}>
                        <i className={hamburger ?  'not-bi bi-x':'bi bi-list'}></i>
                        </button>
                    </nav>
                </div>
                <div className='home-content'>
                    <Routes>
                        <Route path='/' element={<HomeContent/>} />
                        <Route path='/Register' element={<Register/>}/>
                        <Route path='/patientRegister' element={<PatientRegister/>}/>
                        <Route path='/doctorRegister' element={<DoctorRegister/>}/>

                        <Route path='/login' element={<Login/>}/>
                        <Route path='/AboutUs' element={<AboutUs/>}/>

                    </Routes>   

                </div>
        </div>
    );
}

export default Home;