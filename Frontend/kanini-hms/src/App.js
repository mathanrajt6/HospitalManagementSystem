import logo from './logo.svg';
import './App.css';
import Home from './Components/Home/Home';
import Doctor from './Components/Main/Doctor/Doctor';
import Doctors from './Components/Main/Doctors/Doctors';
import Patients from './Components/Main/Patients/Patients';
import Login from './Components/Home/Login/Login';
import PatientRegister from './Components/Home/PatientRegister/PatientRegister';
import DoctorRegister from './Components/Home/DoctorRegister/DoctorRegister';
import { useState } from 'react';
import Main from './Components/Main/main';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginProtected from './Components/Protected/LoginProtected';
import Pending from './Components/Main/Pending/Pendind';
import Rejected from './Components/Main/Rejected/Rejected';
import UpdatePassword from './Components/Main/UpdatePassword/UpdatePassword';

function App() {

 
  return (
    <div className="App">
        <BrowserRouter>
          <Routes>
            <Route path='/*' element={<Home/>} />
            {/* <Route path='/home' element={<Home/>} /> */}
            <Route path='/home/*' element={<Home/>} />
            {/* <Route path='/main/*' element={
                        <LoginProtected role={sessionStorage.getItem('role')} > <Doctors/> </LoginProtected>
              }/> */}
            {/* <Route path='/main' element={<Main/>}/> */}
       
            <Route path='/main/*' element={
                        <LoginProtected role={sessionStorage.getItem('role')} > <Main/> </LoginProtected>
            }/>
                   <Route path='/pending' element={<Pending/>}/>
                   <Route path='/rejected' element={<Rejected/>}/>
                   
          </Routes>
        </BrowserRouter>

    </div>
  );
}

export default App;
