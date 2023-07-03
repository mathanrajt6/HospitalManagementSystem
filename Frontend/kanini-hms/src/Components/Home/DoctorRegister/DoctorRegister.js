import { useState } from 'react';
import './DoctorRegister.css'
import { Link } from 'react-router-dom';

function DoctorRegister()
{
    
    const [doctorRegister,setDoctorRegister] = useState(
        {
            "id": 0,
            "email": "",
            "role": "doctor",
            "userDetail": {
              "userDetailID": 0,
              "firstName": "",
              "lastName": "",
              "dateOfBirth": "",
              "phoneNUmber": "",
              "address": "",
              "gender": "",
              "doctor": {
                "doctorID": 0,
                "consultingFees": 0,
                "specialization": "",
                "yearOfExperience": 0,
                "approvedStatus": "pending",
                "active": "in-active"
              }
            }
          }
    );
    const clear=()=>
    {
       window.location.reload();
    }

    const register=()=>
    {
        if(ValiditeFirstName() && ValiditeSecondName() && VaildateDOB() && ValiditeEmailAddress() && ValiditePhoneNuumber() && ValiditeAddress() && ValiditeSpecialization() && ValiditeYearOfConsultingFees() && ValiditeYearOfExperince())
        {

        console.log(doctorRegister);
        fetch('http://localhost:5199/api/Doctor/DoctorRegister',{
            "method":"POST",
            "headers":
            {
                "accept": "text/plain",
                "Content-Type": 'application/json'   
            },
            "body":JSON.stringify(doctorRegister)}
            ).then(async (data)=>
            {
            if(data.status == 201)
            {
                var user = await data.json()
                sessionStorage.setItem('token',user.token)
                console.log(user)
                clear();
                document.getElementById('regsiter-doctor-validate').innerHTML = "Register sucessfully";

                // if(user.role == 'admin')
                //         navigate('/intern')
                // else{
                //     setMessage("Intern can't able to fetch interns")
                // }
            }
            else
            {

                var error = await data.json()
                document.getElementById('regsiter-doctor-validate').innerHTML = error.errorMessage;
            }
            }
            ).catch((err)=>
            {
                    console.log(err)
            }
            )
        }
        };

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

        /////


        const ValiditeFirstName=()=>
        {
            var firstname =(/^[A-Za-z]{1,50}$/).test(doctorRegister.userDetail.firstName);
            if(firstname)
            {
                console.log(firstname)
                document.getElementById('first-name-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-first-name')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-first-name')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('first-name-validate').innerHTML="First Name should have only alphabet and less than 50 character";
                document.body.getElementsByClassName('doctor-first-name')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-first-name')[0].classList.add('invalid');
            }
            return firstname;
        }
    
        const ValiditeSecondName=()=>
        {
            var lastname = (/^[A-Za-z]{1,50}$/).test(doctorRegister.userDetail.lastName);
            if(lastname)
            {
                document.getElementById('second-name-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-second-name')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-second-name')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('second-name-validate').innerHTML="Second Name should have only alphabet and less than 50 character";
                document.body.getElementsByClassName('doctor-second-name')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-second-name')[0].classList.add('invalid');
            }
            return lastname;
        }
    
    
        const VaildateDOB=()=>
        {
            var age= getAge(doctorRegister.userDetail.dateOfBirth)>18;
            if(age)
            {
                document.getElementById('dob-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-dob')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-dob')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('dob-validate').innerHTML="Age should be greater than 18 ";
                document.body.getElementsByClassName('doctor-dob')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-dob')[0].classList.add('invalid');
            }
            return age;
        }
        
    
        const ValiditePhoneNuumber=()=>
        {
            var phone = (/^[0-9]{10}$/).test(doctorRegister.userDetail.phoneNUmber);
            if(phone)
            {
                document.getElementById('phone-number-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-phone-number')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-phone-number')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('phone-number-validate').innerHTML="Phone number should be 10 digit";
                document.body.getElementsByClassName('doctor-phone-number')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-phone-number')[0].classList.add('invalid');
            }
            return phone;
        }
    
        const ValiditeAddress=()=>
        {
            var address = doctorRegister.userDetail.address.length <=250 && doctorRegister.userDetail.address.length >0 ;
            if(address)
            {
                document.getElementById('address-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-address')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-address')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('address-validate').innerHTML="Address should be less than 250 character";
                document.body.getElementsByClassName('doctor-address')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-address')[0].classList.add('invalid');
            }
            return address;
        }
    
    
        const ValiditeEmailAddress=()=>
        {
            var email = ( /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/).test(doctorRegister.email);
            if(email)
            {
                document.getElementById('email-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-email')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-email')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('email-validate').innerHTML="Invalid email";
                document.body.getElementsByClassName('doctor-email')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-email')[0].classList.add('invalid');
            }
            return email;
        }

        const ValiditeSpecialization=()=>
        {
            var spec = (doctorRegister.userDetail.doctor.specialization.length <=100 && doctorRegister.userDetail.doctor.specialization.length > 0 );
            if(spec)
            {
                document.getElementById('spec-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-spec')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-spec')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('spec-validate').innerHTML="Specialization should be less than 100 characters";
                document.body.getElementsByClassName('doctor-spec')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-spec')[0].classList.add('invalid');
            }
            return spec;
        }

        const ValiditeYearOfExperince=()=>
        {
            console.log(doctorRegister?.userDetail?.doctor?.yearOfExperience)
            var year = (doctorRegister?.userDetail?.doctor?.yearOfExperience > 0 && doctorRegister?.userDetail.doctor?.yearOfExperience<=100);
            if(year)
            {
                document.getElementById('year-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-year')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-year')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('year-validate').innerHTML="Year of Experience should be between 0 and 100";
                document.body.getElementsByClassName('doctor-year')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-year')[0].classList.add('invalid');
            }
            return year;
        }

        const ValiditeYearOfConsultingFees=()=>
        {
            var fee = (doctorRegister.userDetail.doctor.consultingFees > 100 && doctorRegister.userDetail.doctor.consultingFees <=10000);
            if(fee)
            {
                document.getElementById('fee-validate').innerHTML="";
                document.body.getElementsByClassName('doctor-fee')[0].classList.add('valid');
                document.body.getElementsByClassName('doctor-fee')[0].classList.remove('invalid');
            }
            else{
                document.getElementById('fee-validate').innerHTML="Fees shoulf be between 100 and 10000";
                document.body.getElementsByClassName('doctor-fee')[0].classList.remove('valid');
                document.body.getElementsByClassName('doctor-fee')[0].classList.add('invalid');
            }
            return fee;
        }

        //////


    return(
        <div className="doctor-register">
            <div className='doctor-register-container'>
                    <div className='doctor-register-info'>
                        
                    </div>
                    <div className='doctor-register-form'>
                        <div className='doctor-register-form-container'>
                            <h2>
                                Doctor Register
                            </h2>
                            <hr/>
                            <div className='doctor-register-items'>
                            <div className='doctor-register-item'>
                                    <label> First Name</label>
                                    <br/>
                                    <input type='text'  className="doctor-first-name" placeholder='Enter your First Name' value={doctorRegister.userDetail.firstName} onBlur={ValiditeFirstName}
                                    onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["firstName"]: event.target.value } })}
                                    />
                                    <span id='first-name-validate'></span>
                                </div>
                                <div className='doctor-register-item'>
                                    <label> Second Name</label>
                                    <br/>
                                    <input type='email'  className="doctor-second-name" placeholder='Enter your Last name' value={doctorRegister.userDetail.lastName} onBlur={ValiditeSecondName}
                                    onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["lastName"]: event.target.value } })}

                                    />
                                    <span id='second-name-validate'></span>

                                </div> 
                                <div className='doctor-register-item'>
                                   <label>  Gender </label>
                                   <br/>
                                    <input type='radio'  className="login-email" name='gender' id='male' value='male' checked={doctorRegister.userDetail.gender === "male"} 
                                      onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["gender"]: event.target.value } })}

                                    />
                                    <label  htmlFor='male'>Male </label>

                                    <input type='radio'  className="login-email"   name='gender' id='female' value='female' checked={doctorRegister.userDetail.gender === "female"}
                                        onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["gender"]: event.target.value } })}
                                      />
                                    <label  htmlFor='female'> Female </label>

                                    <input type='radio'  className="login-email"  name='gender' id='others' value='other' checked={doctorRegister.userDetail.gender === "other"}
                                        onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["gender"]: event.target.value } })}
                                      />
                                    <label  htmlFor='others'> others </label>

                                </div>
                                <div className='doctor-register-item'>
                                    <label> Date of Birth</label>
                                    <br/>
                                    <input type='date'  className="doctor-dob" value={doctorRegister.userDetail.dateOfBirth} onBlur={VaildateDOB}
                                      onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["dateOfBirth"]: event.target.value } })}
                                    />
                                    <span id='dob-validate'></span>

                                </div>
                                <div className='doctor-register-item'>
                                    <label> Email</label>
                                    <br/>
                                    <input type='email'  className="doctor-email" placeholder='Enter your Email' value={doctorRegister.email} onBlur={ValiditeEmailAddress}
                                      onChange={(event)=>setDoctorRegister({ ...doctorRegister, "email":event.target.value})}
                                    
                                    />
                                     <span id='email-validate'></span>
                                </div>
                                <div className='doctor-register-item'>
                                    <label>  Phone </label>
                                    <br/>
                                    <input type='tel'  className="doctor-phone-number" placeholder='Enter your Phone number' value={doctorRegister.userDetail.phoneNUmber} onBlur={ValiditePhoneNuumber}
                                      onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["phoneNUmber"]: event.target.value } })}
                                    
                                    />
                                    <span id='phone-number-validate'></span>
                                </div>
                                <div className='doctor-register-item'>
                                    <label>  Address </label>
                                    <br/>
                                    <input type='address' className='doctor-address' placeholder='Enter your Address' value={doctorRegister.userDetail.address} onBlur={ValiditeAddress}
                                      onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, ["address"]: event.target.value } })}
                                    
                                    /> 
                                    <span id='address-validate'></span>
                                </div>
                                <div className='doctor-register-item'>
                                    <label> Specialization </label>
                                    <br/>
                                    <input type='tel'  className="doctor-spec" placeholder='Enter your Bkood Group' value={doctorRegister.userDetail.doctor.specialization}  onBlur={ValiditeSpecialization}
                                    onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, doctor:{...doctorRegister.userDetail.doctor,["specialization"]: event.target.value } }})}

                                    
                                    />
                                     <span id='spec-validate'></span>
                                </div>
                                <div className='doctor-register-item'>
                                    <label>  Year of Experince </label>
                                    <br/>
                                    <input type='text'  className="doctor-year" placeholder='Enter your Email' value={doctorRegister.userDetail.doctor.yearOfExperience} onBlur={ValiditeYearOfExperince}
                                    onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, doctor:{...doctorRegister.userDetail.doctor,["yearOfExperience"]: event.target.value } }})}

                                      />
                                       <span id='year-validate'></span>
                                </div>
                                <div className='doctor-register-item'>
                                    <label>  Consulting fees </label>
                                    <br/>
                                    <input type='tel'  className="doctor-fee" placeholder='Enter your Email'  value={doctorRegister.userDetail.doctor.consultingFees} onBlur={ValiditeYearOfConsultingFees}
                                    onChange={(event)=>setDoctorRegister({ ...doctorRegister, userDetail: { ...doctorRegister.userDetail, doctor:{...doctorRegister.userDetail.doctor,["consultingFees"]: event.target.value } }})}

                                      />
                                       <span id='fee-validate'></span>
                                </div>
                                
                             <span id='regsiter-doctor-validate'></span>
                           </div>
                        <div className='btn'>
                                    <button className='doctor-register-btn' onClick={register}> Register </button> 
                                    <button className='doctor-register-btn' onClick={clear}> Clear  </button> 

                                </div>
                                <a className='register-link'><Link to='/patientRegister'>  Move to patient Regsiter </Link>   </a>
                        </div>
                </div>
            </div>
        </div>
    );
}

export default DoctorRegister;