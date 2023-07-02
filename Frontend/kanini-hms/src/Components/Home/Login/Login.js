import { useState } from 'react';
import './Login.css'
import { useNavigate } from 'react-router-dom';

function Login()
{

    const navigate = useNavigate();
    const [togglePass,setTogglePass] = useState(true);
    const togglePassword=()=>
    {
            if(!togglePass)
            {
                document.body.getElementsByClassName('login-password')[0].type ="password";
            }
            else    
                document.body.getElementsByClassName('login-password')[0].type ="text";
                setTogglePass(!togglePass)

    }

    const [userDTO,setUserDTO]=useState(
        {
            "email":"",
            "password":"",
        }  
    );

    var login=()=>{
        if(validateEmail())
        {
            
            console.log(userDTO);
            fetch('http://localhost:5199/api/User/Login',{
                "method":"POST",
                "headers":
                {
                    "accept": "text/plain",
                    "Content-Type": 'application/json'   
                },
                "body":JSON.stringify(userDTO)}
                ).then(async (data)=>
                {
                if(data.status == 200)
                {
                    var user = await data.json()
                    sessionStorage.setItem('token',user.token)
                    sessionStorage.setItem('role',user.role)
                    sessionStorage.setItem('id',user.id)
                    sessionStorage.setItem('doctorStatus',user.status)
                    navigate('/main');

                    // if(user.role == 'admin')
                    //         navigate('/intern')
                    // else{
                    //     setMessage("Intern can't able to fetch interns")
                    // }
                }
                else
                {
    
                    var error = await data.json()
                    document.body.getElementsByClassName('login-validation')[0].innerHTML=error.errorMessage;
                    console.log(error.errorMessage)

                }
                }
                ).catch((err)=>
                {
    
                }
                )
    
            };
        }
        

        const validateEmail = () => {
            if(( /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/).test(userDTO.email))
            {
                document.body.getElementsByClassName('login-email')[0].classList.add('valid');
                document.body.getElementsByClassName('login-validation')[0].innerHTML=" ";
                document.body.getElementsByClassName('login-email')[0].classList.remove('invalid');

            }
            else
            {
                document.body.getElementsByClassName('login-email')[0].classList.remove('valid');
                document.body.getElementsByClassName('login-validation')[0].innerHTML="invalid email";
                document.body.getElementsByClassName('login-email')[0].classList.add('invalid');
            }
            return ( /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/).test(userDTO.email);
          };
    return(
        <div className="login">
            <div className='login-container'>
                <div className='login-info'>
                        g
                </div>
                <div className='login-form'>
                    <div className='login-from-container'>
                        <h1>
                            Login
                        </h1>
                        <hr/>
                        <i onClick={togglePassword} className={togglePass ?  'not-bi bi-eye show-password':'bi bi-eye-slash show-password'}></i>
                        <input type='email'  className="login-email" placeholder='Enter your Email' onChange={(event)=>setUserDTO({...userDTO,"email":event.target.value})} onBlur={validateEmail}/>
                        <input type='password' className="login-password" placeholder='Enter your Password'  onChange={(event)=>setUserDTO({...userDTO,"password":event.target.value})}/> 
                        <span className='login-validation' id='login-validation'></span>
                        <div className='btn'>
                            <button className='login-btn' onClick={login}> login </button> 
                        </div>
                        <a className='register-link'> Create new Account  </a>

                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;