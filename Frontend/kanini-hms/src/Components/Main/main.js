import { useState } from "react";
import DoctorRegister from "../Home/DoctorRegister/DoctorRegister";
import './main.css'
import Patients from "./Patients/Patients";
import Doctors from "./Doctors/Doctors";
import PatientRegister from "../Home/PatientRegister/PatientRegister";
import { Link, Navigate, Route, Routes, unstable_HistoryRouter, useNavigate } from "react-router-dom";
import AdminProtected from "../Protected/AdminProtected";
import DoctorProtected from "../Protected/DoctorProtected";
import Home from "../Home/Home";
function Main()
{
    const navigate = useNavigate();
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
        <div className="main">
        <div className='main-header'>
                        <nav>
                            <label className='header-title'>
                                KANINI HMS
                            </label>
                            <label className='hamburger'>
                                
                            </label>
                            <ul className='header-link'>
                                {/* {sessionStorage.getItem('role').toLowerCase() === 'admin'  || sessionStorage.getItem('role').toLowerCase() === 'admin' ?
                                     (<li className='header-link-item'> <Link to='/main/doctors' onClick={toggle}>Doctor</Link> </li>)
                                    :
                                    (<li className='header-link-item'> <Link  to='/main/patients' onClick={toggle}> Patient  </Link> </li>)
                                } */}
                                <li className='header-link-item'> <Link to='/main/doctors' onClick={toggle} > Doctor </Link> </li>
                                <li className='header-link-item'> <Link  to='/main/patients' onClick={toggle}> Patient </Link> </li>
                                <li className='header-link-item'> <Link onClick={toggle} > Profile </Link> </li>
                                <li className='header-link-item'> <Link to='/' onClick={toggle}> Logout </Link> </li>
                            </ul>
                            <button className='hamburger' onClick={toggle}>
                            <i className={hamburger ?  'not-bi bi-x':'bi bi-list'}></i>
                            </button>
                        </nav>
                    </div>
            <div className='main-content'>
                <Routes>
                    
                    {/* <Route path='/main/doctors' element={
                        <AdminProtected role={sessionStorage.getItem('role')} > <Doctors/> </AdminProtected>
                    }/> */}
                    <Route path='/doctors' element={<Doctors/>}/>
                    <Route path='/patients' element={<Patients/> }/>
                    

                    {/* <Route path='/main/doctors' element={
                        <AdminProtected role={sessionStorage.getItem('role')} > <Doctors/> </AdminProtected>
                    }/>
                      <Route path='/main/patients' element={
                        <DoctorProtected role={sessionStorage.getItem('role')} > <Patients/> </DoctorProtected>
                    }/> */}
                    
                   

                </Routes>
            </div>
        </div>
    );
}

export default Main;