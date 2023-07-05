import { Link } from "react-router-dom";
import './DetailsUpdate.css'
import { useEffect, useState } from "react";
import male from '../../../Asset/male.png';
import female from '../../../Asset/female.png';
import { toast } from "react-toastify";

function DetailsUpdate()
{

    
    const [enable,setEnable] = useState(true);
    const [user,setUser] = useState(
        {
            "doctor": {
              "doctorID": 0,
              "consultingFees": 0,
              "specialization": "",
              "yearOfExperience": 0,
              "approvedStatus": "",
              "active": ""
            },
            "userDetailID":0 ,
            "firstName": "",
            "lastName": "",
            "email": "",
            "age": 24,
            "dateOfBirth": "",
            "phoneNUmber": "",
            "address": "",
            "gender": "",
            "patient": {
                "patientID": 0,
                "emergencyContactName": "",
                "emergencyContactPhone": "",
                "bloodGroup": ""
              }
          }
    );
    

    


    const getAdmin=(id)=>
    {
            console.log(id)
            fetch('http://localhost:5199/api/Admin/GetAdminDetails', {
              "method": 'POST',
              "headers": {
                "accept": 'text/plain',
                'Content-Type': 'application/json',
                "Authorization": 'Bearer ' + sessionStorage.getItem('token')
              },
              "body": JSON.stringify(id),
            })
              .then(async (data) => {
                if (data.status === 200) {
                    var admin= await  data.json();
                    console.log(admin);
                    setUser(admin)
                } 
              })
              .catch((err) => {
                console.log(err);
              });
          
    }

    const getPatient=(id)=>
    {
        fetch('http://localhost:5199/api/Patient/GetPatientDetails', {
            "method": 'POST',
            "headers": {
              "accept": 'text/plain',
              'Content-Type': 'application/json',
              "Authorization": 'Bearer ' + sessionStorage.getItem('token')
            },
            "body": JSON.stringify(id),
          })
            .then(async(data) => {
              if (data.status === 200) {
                var admin= await  data.json();
                    console.log(data);
                    setUser(admin)
              } 
            })
            .catch((err) => {
              console.log(err);
            });
    }

    const getDoctor=(id)=>
    {
        fetch('http://localhost:5199/api/Doctor/GetDoctorDetails', {
            "method": 'POST',
            "headers": {
              "accept": 'text/plain',
              'Content-Type': 'application/json',
              "Authorization": 'Bearer ' + sessionStorage.getItem('token')
            },
            "body": JSON.stringify(id),
          })
            .then(async (data) => {
              if (data.status === 200) {
                var admin= await  data.json();
                console.log(admin);
                setUser(admin)
              } 
            })
            .catch((err) => {
              console.log(err);
            });
    }

    
    useEffect(()=>{
     
       
        get();
        
    },[])

    
        const  get=()=>
        {
            var UserId = {
                "id":Number(sessionStorage.getItem('id'))
                }
        if(sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="admin" )
        {
            getAdmin(UserId);
        }
        else if(sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="doctor" )
        {
            getDoctor(UserId);
        }
        else
        {
            getPatient(UserId);
        }
        };

    const register=()=>
    {   
        if(VaildateDOB() && ValiditeAddress() && ValiditePhoneNuumber())
        {
            if(sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="admin" )
            {
                updateAdmin();
                setEnable(!enable);

            }
            if(sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="doctor" && ValiditeYearOfExperince() && ValiditeYearOfConsultingFees() && ValiditeSpecialization() )
            {
                updateDoctor();
                setEnable(!enable);

            }
            if(sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="patient" &&  validateEmergencyName() && validateEmergencyPhone() && validateBloogdGroup() )
            {
                updatePatient();
                setEnable(!enable);

            }
        }
    }

    const updateAdmin=()=>
    {
           var adminDetails= {
            "id": user.userDetailID,
            "dateOfBirth": user.dateOfBirth,
            "address": user.address,
            "phone": user.phoneNUmber
          }
          console.log(adminDetails)
          fetch('http://localhost:5199/api/Admin/UpdateAdminDetails',{
              "method":"PUT",
              "headers":
              {
                  "accept": "text/plain",
                  "Content-Type": 'application/json',
                  "Authorization": 'Bearer ' + sessionStorage.getItem('token')
  
              },
              "body":JSON.stringify(adminDetails)}
          ).then(async (data)=>
          {
              if(data.status === 202)
              {
                toast.success('Profile Updated Sucessfully!', {
                    position: toast.POSITION.BOTTOM_RIGHT
                });
                
              }
              else
              {
                toast.error('Unable to update', {
                    position: toast.POSITION.BOTTOM_RIGHT
                });

              
              }
          }
          ).catch((err)=>
          {
          console.log(err.error)
          }
          )
        
    }

    const updateDoctor=()=>
    {
        var doctorDetails ={
            "id": user.userDetailID,
            "dateOfBirth": user.dateOfBirth,
            "address": user.address,
            "phone": user.phoneNUmber,
            "consultingFees": user.doctor.consultingFees,
            "specialization": user.doctor.specialization,
            "yearOfExperience": user.doctor.yearOfExperience
          }
          fetch('http://localhost:5199/api/Doctor/UpdateDoctorDetails',{
              "method":"PUT",
              "headers":
              {
                  "accept": "text/plain",
                  "Content-Type": 'application/json',
                  "Authorization": 'Bearer ' + sessionStorage.getItem('token')
  
              },
              "body":JSON.stringify(doctorDetails)}
          ).then(async (data)=>
          {
              if(data.status === 202)
              {
                toast.success('Profile Updated Sucessfully!', {
                    position: toast.POSITION.BOTTOM_RIGHT
                });
                
              }
              else
              {
                toast.error('Unable to update', {
                    position: toast.POSITION.BOTTOM_RIGHT
                });

              
              }
          }
          ).catch((err)=>
          {
          console.log(err.error)
          }
          )
        
    }

    const updatePatient=()=>
    {
        var PatientDetails ={
            "id": user.userDetailID,
            "dateOfBirth": user.dateOfBirth,
            "address": user.address,
            "phone": user.phoneNUmber,
            "emergencyContactName": user.patient.emergencyContactName,
            "emergencyContactPhone": user.patient.emergencyContactPhone,
            "bloodGroup": user.patient.bloodGroup
          }
       
          fetch('http://localhost:5199/api/Patient/UpdatePatientDetails',{
              "method":"PUT",
              "headers":
              {
                  "accept": "text/plain",
                  "Content-Type": 'application/json',
                  "Authorization": 'Bearer ' + sessionStorage.getItem('token')
  
              },
              "body":JSON.stringify(PatientDetails)}
          ).then(async (data)=>
          {
              if(data.status === 202)
              
                {
                    toast.success('Profile Updated Sucessfully!', {
                        position: toast.POSITION.BOTTOM_RIGHT
                    });
                    
                  }
                else
                  {
                    var error = await data.json()
                    toast.error(error.errorMessage, {
                        position: toast.POSITION.BOTTOM_RIGHT
                    });
    
                  
                  }
          }
          ).catch((err)=>
          {
          console.log(err.error)
          }
          )
        
    }


    const toggleEnable=()=>
    {
        setEnable(!enable);
    }

    const cancel=()=>
    {
        setEnable(!enable);
        get();

    }



    //
    function getAge(d1) {
        var d1= new Date(d1);
        var d2 = new Date();
        var age = d2.getFullYear() - d1.getFullYear();
      
        if (d2.getMonth() < d1.getMonth() || (d2.getMonth() === d1.getMonth() && d2.getDate() < d1.getDate())) {
          age--;
        }
      
        console.log(age);
        return age;
      }

    const VaildateDOB=()=>
    {
        var age= getAge(user.dateOfBirth)>18;
        if(age)
        {
            document.getElementById('dob-validate').innerHTML="";
            document.body.getElementsByClassName('dob')[0].classList.add('valid');
            document.body.getElementsByClassName('dob')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('dob-validate').innerHTML="Age should be greater than 18 ";
            document.body.getElementsByClassName('dob')[0].classList.remove('valid');
            document.body.getElementsByClassName('dob')[0].classList.add('invalid');
        }
        return age;
    }
    

    const ValiditePhoneNuumber=()=>
    {
        var phone = (/^[0-9]{10}$/).test(user.phoneNUmber);
        if(phone)
        {
            document.getElementById('phone-number-validate').innerHTML="";
            document.body.getElementsByClassName('phone-number')[0].classList.add('valid');
            document.body.getElementsByClassName('phone-number')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('phone-number-validate').innerHTML="Phone number should be 10 digit";
            document.body.getElementsByClassName('phone-number')[0].classList.remove('valid');
            document.body.getElementsByClassName('phone-number')[0].classList.add('invalid');
        }
        return phone;
    }

    const ValiditeAddress=()=>
    {
        var address = user.address.length <=250 && user.address.length >0 ;
        if(address)
        {
            document.getElementById('address-validate').innerHTML="";
            document.body.getElementsByClassName('address')[0].classList.add('valid');
            document.body.getElementsByClassName('address')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('address-validate').innerHTML="Address should be less than 250 character";
            document.body.getElementsByClassName('address')[0].classList.remove('valid');
            document.body.getElementsByClassName('address')[0].classList.add('invalid');
        }
        return address;
    }



    
    const validateEmergencyName=()=>
    {
        var emerName = (/^[A-Za-z]{1,50}$/).test(user.patient.emergencyContactName);
        if(emerName)
        {
            document.getElementById('emergency-name-validate').innerHTML="";
            document.body.getElementsByClassName('emergency-name')[0].classList.add('valid');
            document.body.getElementsByClassName('emergency-name')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('emergency-name-validate').innerHTML=" Name should have only alphabet and less than 50 character";
            document.body.getElementsByClassName('emergency-name')[0].classList.remove('valid');
            document.body.getElementsByClassName('emergency-name')[0].classList.add('invalid');
        }
        return emerName;
    }

    
    const validateEmergencyPhone=()=>
    {
        var emerPhone = ( /^[0-9]{10}$/).test(user.patient.emergencyContactPhone);
        if(emerPhone)
        {
            document.getElementById('emergency-phone-validate').innerHTML="";
            document.body.getElementsByClassName('emergency-phone')[0].classList.add('valid');
            document.body.getElementsByClassName('emergency-phone')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('emergency-phone-validate').innerHTML="Phone number should be 10 digit";
            document.body.getElementsByClassName('emergency-phone')[0].classList.remove('valid');
            document.body.getElementsByClassName('emergency-phone')[0].classList.add('invalid');
        }
        return emerPhone;
    }

    
    const validateBloogdGroup=()=>
    {
        var blooggroup = user.patient.bloodGroup.length<=50 && user.patient.bloodGroup.length>0;
        if(blooggroup)
        {
            document.getElementById('blood-group-validate').innerHTML="";
            document.body.getElementsByClassName('blood-group')[0].classList.add('valid');
            document.body.getElementsByClassName('blood-group')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('blood-group-validate').innerHTML="name should be less than 50 character";
            document.body.getElementsByClassName('blood-group')[0].classList.remove('valid');
            document.body.getElementsByClassName('blood-group')[0].classList.add('invalid');
        }
        return blooggroup;
    }

    const ValiditeSpecialization=()=>
    {
        var spec = (user.doctor.specialization.length <=100 && user.doctor.specialization.length > 0 );
        if(spec)
        {
            document.getElementById('spec-validate').innerHTML="";
            document.body.getElementsByClassName('spec')[0].classList.add('valid');
            document.body.getElementsByClassName('spec')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('spec-validate').innerHTML="Specialization should be less than 100 characters";
            document.body.getElementsByClassName('spec')[0].classList.remove('valid');
            document.body.getElementsByClassName('spec')[0].classList.add('invalid');
        }
        return spec;
    }

    const ValiditeYearOfExperince=()=>
    {
        var year = (user?.doctor?.yearOfExperience > 0 && user.doctor?.yearOfExperience<=100);
        if(year)
        {
            document.getElementById('year-validate').innerHTML="";
            document.body.getElementsByClassName('year')[0].classList.add('valid');
            document.body.getElementsByClassName('year')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('year-validate').innerHTML="Year of Experience should be between 0 and 100";
            document.body.getElementsByClassName('year')[0].classList.remove('valid');
            document.body.getElementsByClassName('year')[0].classList.add('invalid');
        }
        return year;
    }

    const ValiditeYearOfConsultingFees=()=>
    {
        var fee = (user.doctor.consultingFees > 100 && user.doctor.consultingFees <=10000);
        if(fee)
        {
            document.getElementById('fee-validate').innerHTML="";
            document.body.getElementsByClassName('fee')[0].classList.add('valid');
            document.body.getElementsByClassName('fee')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('fee-validate').innerHTML="Fees shoulf be between 100 and 10000";
            document.body.getElementsByClassName('fee')[0].classList.remove('valid');
            document.body.getElementsByClassName('fee')[0].classList.add('invalid');
        }
        return fee;
    }


    //
    return(
        <div className="update">
            <h2>
                    User details
                </h2>
                <hr/>
        <div className="details-update">
             
            <div className="details-update-non-editable">
                <div className="non-editable-item" id="profile-image">
                        <img width='200' height='200' src={user.gender=="male" ? male : female}/>
                </div>
            <div className='non-editable-item'>
                <label> First Name</label>
                <br/>
              
                <input type='text' value={user.firstName}   className="first-name" placeholder='Enter your fees' disabled={enable}/>
                <span id='first-name-validate'></span>
            </div>
            <div className='non-editable-item'>
                <label> Second Name</label>
                <br/>
                <input type='text' value={user.lastName}  className="second-name" placeholder='Enter your fees'  disabled={enable}
                
                />
               
                <span id='second-name-validate'></span>

            </div> 

            <div className='non-editable-item'>
                <label>  Gender </label>
                <br/>
                <input type='text' value={user.gender}   className="Gender" placeholder='Enter your fees'  disabled={enable}/>

            </div>
            <div className='non-editable-item'>
                    <label> Email</label>
                    <br/>
                   
                    <input type='email' value={user.email}  className="email" placeholder='Enter your fees'  disabled={enable} />
                        <span id='email-validate'></span>
                </div>
                

            </div>
            <div className="details-update-editable">
               
               <div className="editable-container">
                                
                              
               <div className='editable-item'>
                    <label> Date of Birth</label>
                    <br/>
                  
                    <input type={enable ? "text":"date"} value={user.dateOfBirth.substring(0,10)}   className={enable ? "dob border-remove" : "dob"} placeholder='Enter your fees'  disabled={enable}
                    onChange={(event)=>{setUser({...user,"dateOfBirth":event.target.value})}} onBlur={VaildateDOB}
                    />
                    <span id='dob-validate'></span>

                </div>

               
                <div className='editable-item'>
                    <label>  Phone </label>
                    <br/>
                   
                    <input type='tel' value={user.phoneNUmber}  className={enable ? "phone-number border-remove" : "phone-number"}  placeholder='Enter your fees'  disabled={enable}
                    onChange={(event)=>{setUser({...user,"phoneNUmber":event.target.value})}} onBlur={ValiditePhoneNuumber}
                    
                    />
                    <span id='phone-number-validate'></span>
                </div>

                <div className='editable-item'>
                    <label>  Address </label>
                    <br/>
                   
                    <input type='text' value={user.address}   className={enable ? "address border-remove" : "address"}  placeholder='Enter your fees'  disabled={enable}
                    onChange={(event)=>{setUser({...user,"address":event.target.value})}} onBlur={ValiditeAddress}
                    
                    />
                    <span id='address-validate'></span>
                </div>
                {sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="admin" ?
                    (<div className="admin-hide"></div>
                    )
                : 
                    (sessionStorage.getItem('role')!= null && sessionStorage.getItem('role')==="doctor" ?
                    
                    <>
                     <div className='editable-item'>
                        <label> Specialization </label>
                        <br/>
                        
                        <input type='text'  value={user.doctor.specialization}  className={enable ? "spec border-remove" : "spec"} placeholder='Enter your fees'  disabled={enable}
                             onChange={(event)=>setUser({ ...user, doctor: { ...user.doctor, ["specialization"]: event.target.value } })}
                             onBlur={ValiditeSpecialization}
                        
                        />
                            <span id='spec-validate'></span>
                    </div>

                 <div className='editable-item'>
                     <label>  Year of Experince </label>
                    <br/>
                 
                        <input type='number' value={user.doctor.yearOfExperience}  className={enable ? "year border-remove" : "year"} placeholder='Enter your fees'   disabled={enable}
                        onChange={(event)=>setUser({ ...user, doctor: { ...user.doctor, ["yearOfExperience"]: event.target.value } })}
                        onBlur={ValiditeYearOfExperince}
                        />
                        <span id='year-validate'></span>
                </div>
                
                        
                <div className='editable-item'>
                    <label>  Consulting fees </label>
                    <br/>

                    <input type='number'  value={user.doctor.consultingFees} className={enable ? "fee border-remove" : "fee"} placeholder='Enter your fees'  disabled={enable}
                    onChange={(event)=>setUser({ ...user, doctor: { ...user.doctor, ["consultingFees"]: event.target.value } })}
                    onBlur={ValiditeYearOfConsultingFees}
                    />
                <span id='fee-validate'></span>
                </div>
                </>
                    
                :
                
                   <>
                   <div className='patient-register-item'>
                    <label> Blood group </label>
                    <br/>
                    <input type='text' value={user.patient.bloodGroup}  className={enable ? "blood-group border-remove" : "blood-group"} placeholder='Enter your fees'  disabled={enable}
                    onChange={(event)=>setUser({ ...user, patient: { ...user.patient, ["bloodGroup"]: event.target.value } })}
                    
                    onBlur={validateBloogdGroup}
                    />
                    <span id='blood-group-validate'></span>
                    </div>
                
                 <div className='patient-register-item'>
                     <label>  Emergency Contact Name </label>
                     <br/>
                     <input type='text'  value={user.patient.emergencyContactName} className={enable ? "emergency-name border-remove" : "emergency-name"} placeholder='Enter your fees'  disabled={enable}
                        onChange={(event)=>setUser({ ...user, patient: { ...user.patient, ["emergencyContactName"]: event.target.value } })}
                        onBlur={validateEmergencyName}
                     />
                       <span id='emergency-name-validate'></span>
                 </div>
                 
                 <div className='patient-register-item'>
                    <label>  Emergency Contact number </label>
                    <br/>
                     <input type='text'   value={user.patient.emergencyContactPhone}  className={enable ? "emergency-phone border-remove" : "emergency-phone"} placeholder='Enter your fees'  disabled={enable} 
                        onChange={(event)=>setUser({ ...user, patient: { ...user.patient, ["emergencyContactPhone"]: event.target.value } })}
                        onBlur={validateEmergencyPhone}
                     />
                       <span id='emergency-phone-validate'></span>
                 </div>
                 </>
                
                    )
                }
                    {!enable ?
                    <>
                      <button className='update-btn' onClick={register} > Register </button> 
                      <button className='cancel-btn' onClick={cancel} > cancel  </button> 
                      </>
                      :
                      <>
                      <div className="admin-hide"></div>
                      <button className='cancel-btn' onClick={toggleEnable} > edit  </button> 
                      </>
                    
                }
                          
               </div>
                                
                           
                </div>
            </div>
            </div>
    );
}


export default DetailsUpdate;