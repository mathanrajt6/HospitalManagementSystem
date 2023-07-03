import { useState } from 'react';
import './PatientRegister.css'
import { Link } from 'react-router-dom';

function PatientRegister()
{

    const [patientRegister,setPatientRegister] = useState(
        {
            "id": 0,
            "email": "",
            "role": "patient",
            "userDetail": {
              "userDetailID": 0,
              "firstName": "",
              "lastName": "",
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
          }
    );
    const clear=()=>
    {
       window.location.reload();
    }

    ///
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
    //// Validation Regitser

    const ValiditeFirstName=()=>
    {
        var firstname =(/^[A-Za-z]{1,50}$/).test(patientRegister.userDetail.firstName);
        if(firstname)
        {
            document.getElementById('first-name-validate').innerHTML="";
            document.body.getElementsByClassName('patient-first-name')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-first-name')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('first-name-validate').innerHTML="First Name should have only alphabet and less than 50 character";
            document.body.getElementsByClassName('patient-first-name')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-first-name')[0].classList.add('invalid');
        }
        return firstname;
    }

    const ValiditeSecondName=()=>
    {
        var lastname = (/^[A-Za-z]{1,50}$/).test(patientRegister.userDetail.lastName);
        if(lastname)
        {
            document.getElementById('second-name-validate').innerHTML="";
            document.body.getElementsByClassName('patient-second-name')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-second-name')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('second-name-validate').innerHTML="Second Name should have only alphabet and less than 50 character";
            document.body.getElementsByClassName('patient-second-name')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-second-name')[0].classList.add('invalid');
        }
        return lastname;
    }


    const VaildateDOB=()=>
    {
        var age= getAge(patientRegister.userDetail.dateOfBirth)>18;
        if(age)
        {
            document.getElementById('dob-validate').innerHTML="";
            document.body.getElementsByClassName('patient-dob')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-dob')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('dob-validate').innerHTML="Age should be greater than 18 ";
            document.body.getElementsByClassName('patient-dob')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-dob')[0].classList.add('invalid');
        }
        return age;
    }
    

    const ValiditePhoneNuumber=()=>
    {
        var phone = (/^[0-9]{10}$/).test(patientRegister.userDetail.phoneNUmber);
        if(phone)
        {
            document.getElementById('phone-number-validate').innerHTML="";
            document.body.getElementsByClassName('patient-phone-number')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-phone-number')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('phone-number-validate').innerHTML="Phone number should be 10 digit";
            document.body.getElementsByClassName('patient-phone-number')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-phone-number')[0].classList.add('invalid');
        }
        return phone;
    }

    const ValiditeAddress=()=>
    {
        var address = patientRegister.userDetail.address.length <=250 && patientRegister.userDetail.address.length >0 ;
        if(address)
        {
            document.getElementById('address-validate').innerHTML="";
            document.body.getElementsByClassName('patient-address')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-address')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('address-validate').innerHTML="Address should be less than 250 character";
            document.body.getElementsByClassName('patient-address')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-address')[0].classList.add('invalid');
        }
        return address;
    }


    const ValiditeEmailAddress=()=>
    {
        var email = ( /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/).test(patientRegister.email);
        if(email)
        {
            document.getElementById('email-validate').innerHTML="";
            document.body.getElementsByClassName('patient-email')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-email')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('email-validate').innerHTML="Invalid email";
            document.body.getElementsByClassName('patient-email')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-email')[0].classList.add('invalid');
        }
        return email;
    }

    const validateEmergencyName=()=>
    {
        var emerName = (/^[A-Za-z]{1,50}$/).test(patientRegister.userDetail.patient.emergencyContactName);
        if(emerName)
        {
            document.getElementById('emergency-name-validate').innerHTML="";
            document.body.getElementsByClassName('patient-emergency-name')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-emergency-name')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('emergency-name-validate').innerHTML=" Name should have only alphabet and less than 50 character";
            document.body.getElementsByClassName('patient-emergency-name')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-emergency-name')[0].classList.add('invalid');
        }
        return emerName;
    }

    
    const validateEmergencyPhone=()=>
    {
        var emerPhone = ( /^[0-9]{10}$/).test(patientRegister.userDetail.patient.emergencyContactPhone);
        if(emerPhone)
        {
            document.getElementById('emergency-phone-validate').innerHTML="";
            document.body.getElementsByClassName('patient-emergency-phone')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-emergency-phone')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('emergency-phone-validate').innerHTML="Phone number should be 10 digit";
            document.body.getElementsByClassName('patient-emergency-phone')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-emergency-phone')[0].classList.add('invalid');
        }
        return emerPhone;
    }

    
    const validateBloogdGroup=()=>
    {
        var blooggroup = patientRegister.userDetail.patient.bloodGroup.length<=50 && patientRegister.userDetail.patient.bloodGroup.length>0;
        if(blooggroup)
        {
            document.getElementById('blood-group-validate').innerHTML="";
            document.body.getElementsByClassName('patient-blood-group')[0].classList.add('valid');
            document.body.getElementsByClassName('patient-blood-group')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('blood-group-validate').innerHTML="name should be less than 50 character";
            document.body.getElementsByClassName('patient-blood-group')[0].classList.remove('valid');
            document.body.getElementsByClassName('patient-blood-group')[0].classList.add('invalid');
        }
        return blooggroup;
    }


    ////
    const register=()=>
    {
        if(ValiditeFirstName() && ValiditeSecondName() && VaildateDOB() && ValiditeEmailAddress() && ValiditePhoneNuumber() && ValiditeAddress() && validateBloogdGroup() && validateEmergencyName() && validateEmergencyPhone())
        {
        console.log(patientRegister);
        fetch('http://localhost:5199/api/Patient/PatientRegister',{
            "method":"POST",
            "headers":
            {
                "accept": "text/plain",
                "Content-Type": 'application/json'   
            },
            "body":JSON.stringify(patientRegister)}
            ).then(async (data)=>
            {
            if(data.status == 201)
            {
                var user = await data.json()
                sessionStorage.setItem('token',user.token)
                console.log(user)
                document.getElementById('patient-register-validate').innerHTML = "Registered Sucessfully";
                clear();
                // if(user.role == 'admin')
                //         navigate('/intern')
                // else{
                //     setMessage("Intern can't able to fetch interns")
                // }
            }
            else
            {

                var error = await data.json()
                document.getElementById('patient-register-validate').innerHTML = error.errorMessage;
            }
            }
            ).catch((err)=>
            {
                    console.log(err)
            }
            )
        }
        };

    

    return(
        <div className="patient-register">
            <div className='patient-register-container'>
                    <div className='patient-register-info'>
                    </div>
                    <div className='patient-register-form'>
                        <div className='patient-register-form-container'>
                            <h3>
                                Patient Register
                            </h3>
                            <hr/>
                           <div className='patient-register-items'>
                            <div className='patient-register-item'>
                                    <label> First Name</label>
                                    <br/>
                                    <input type='text'  className="patient-first-name" placeholder='Enter your First Name' value={patientRegister.userDetail.firstName} onBlur={ValiditeFirstName}
                                    onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["firstName"]: event.target.value } })}
                                    />
                                    <span id='first-name-validate'></span>
                                </div>
                                <div className='patient-register-item'>
                                    <label> Second Name</label>
                                    <br/>
                                    <input type='email'  className="patient-second-name" placeholder='Enter your Last name' value={patientRegister.userDetail.lastName} onBlur={ValiditeSecondName}
                                    onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["lastName"]: event.target.value } })}
                                    />
                                    <span id='second-name-validate'></span>

                                </div> 
                                <div className='patient-register-item'>
                                   <label>  Gender </label>
                                   <br/>
                                    <input type='radio'   name='gender' id='male' value='male' checked={patientRegister.userDetail.gender === "male"}
                                      onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["gender"]: event.target.value } })}

                                    />
                                    <label  htmlFor='male'>Male </label>

                                    <input type='radio'     name='gender' id='female' value='female' checked={patientRegister.userDetail.gender === "female"}
                                        onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["gender"]: event.target.value } })}
                                      />
                                    <label  htmlFor='female'> Female </label>

                                    <input type='radio' name='gender' id='others' value='other' checked={patientRegister.userDetail.gender === "other"}
                                        onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["gender"]: event.target.value } })}
                                      />
                                    <label  htmlFor='others'> others </label>

                                </div>
                                <div className='patient-register-item'>
                                    <label> Date of Birth</label>
                                    <br/>
                                    <input type='date'  className="patient-dob" value={patientRegister.userDetail.dateOfBirth} onBlur={VaildateDOB}
                                      onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["dateOfBirth"]: event.target.value } })}
                                    />
                                    <span id='dob-validate'></span>
                                </div>
                                <div className='patient-register-item'>
                                    <label> Email</label>
                                    <br/>
                                    <input type='email'  className="patient-email" placeholder='Enter your Email' value={patientRegister.email} onBlur={ValiditeEmailAddress}
                                      onChange={(event)=>setPatientRegister({ ...patientRegister, "email":event.target.value})}
                                    
                                    />
                                       <span id='email-validate'></span>
                                </div>
                                <div className='patient-register-item'>
                                    <label>  Phone </label>
                                    <br/>
                                    <input type='tel'  className="patient-phone-number" placeholder='Enter your Phone number' value={patientRegister.userDetail.phoneNUmber} onBlur={ValiditePhoneNuumber}
                                      onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["phoneNUmber"]: event.target.value } })}
                                    
                                    />
                                       <span id='phone-number-validate'></span>

                                </div>
                                <div className='patient-register-item'>
                                    <label>  Address </label>
                                    <br/>
                                    <input type='address'   className="patient-address"  placeholder='Enter your Address' value={patientRegister.userDetail.address} onBlur={ValiditeAddress}
                                      onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, ["address"]: event.target.value } })}
                                    
                                    /> 
                                       <span id='address-validate'></span>

                                </div>
                                <div className='patient-register-item'>
                                    <label> Blood group </label>
                                    <br/>
                                    <input type='tel'  className="patient-blood-group"placeholder='Enter your Bkood Group' value={patientRegister.userDetail.patient.bloodGroup} onBlur={validateBloogdGroup}
                                    onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, patient:{...patientRegister.userDetail.patient,["bloodGroup"]: event.target.value } }})}

                                    
                                    />
                                    <span id='blood-group-validate'></span>
                                </div>
                                <div className='patient-register-item'>
                                    <label>  Emergency Contact Name </label>
                                    <br/>
                                    <input type='text'  className="patient-emergency-name" placeholder='Enter your Email' value={patientRegister.userDetail.patient.emergencyContactName} onBlur={validateEmergencyName}
                                    onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, patient:{...patientRegister.userDetail.patient,["emergencyContactName"]: event.target.value } }})}

                                      />
                                      <span id='emergency-name-validate'></span>
                                </div>
                                <div className='patient-register-item'>
                                    <label>  Emergency Contact number </label>
                                    <br/>
                                    <input type='tel'  className="patient-emergency-phone" placeholder='Enter your Email'  value={patientRegister.userDetail.patient.emergencyContactPhone} onBlur={validateEmergencyPhone}
                                    onChange={(event)=>setPatientRegister({ ...patientRegister, userDetail: { ...patientRegister.userDetail, patient:{...patientRegister.userDetail.patient,["emergencyContactPhone"]: event.target.value } }})}

                                      />
                                      <span id='emergency-phone-validate'></span>
                                </div>
                                <span id='patient-register-validate'></span>
                                
                             
                           </div>
                           <div className='btn'>
                                    <button className='patient-register-btn' onClick={register}> Register </button> 
                                    <button className='patient-register-btn' onClick={clear}> Clear  </button> 

                                </div>
                                <a className='register-link'> <Link to='/doctorRegister'>  Move to Doctor Regsiter </Link> </a>

                        </div>
                </div>
            </div>
        </div>
    );
}

export default PatientRegister;