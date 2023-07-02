import { useState } from 'react';
import Header from './Header/Header';
import HomeContent from './Home Content/HomeContent';
import './Home.css'
import Login from './Login/Login';
import PatientRegister from './PatientRegister/PatientRegister';
import DoctorRegister from './DoctorRegister/DoctorRegister';
import { Link, Route, Routes } from 'react-router-dom';

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
    return(
        <div className="home">
                <div className='home-header'>
                    <nav>
                        <label className='header-title'>
                            <Link onClick={toggle} to='/home/ ' className='logo' >KANINI HMS</Link> 
                        </label>
                        <label className='hamburger'>
                            
                        </label>
                        <ul className='header-link'>
                            <li className='header-link-item'> <Link onClick={toggle} to='/home/login'>Login</Link> </li>
                            <li className='header-link-item'> <Link onClick={toggle} to='/home/Register'>Register</Link> </li>
                            <li className='header-link-item'>  <Link to='/home/login'  onClick={toggle}>About us</Link> </li>
                            <li className='header-link-item'><Link to='/home/login'  onClick={toggle} >Contact us</Link> </li>
                        </ul>
                        <button className='hamburger' onClick={toggle}>
                        <i className={hamburger ?  'not-bi bi-x':'bi bi-list'}></i>
                        </button>
                    </nav>
                </div>
                <div className='home-content'>
                    <Routes>
                        <Route path='/' element={<HomeContent/>} />
                        <Route path='/Register' element={<DoctorRegister/>}/>
                        <Route path='/register' element={<PatientRegister/>}/>
                        <Route path='/login' element={<Login/>}/>
                    </Routes>   

                </div>
        </div>
    );
}

export default Home;