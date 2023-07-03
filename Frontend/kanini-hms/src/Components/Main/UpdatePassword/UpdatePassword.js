import { useState } from 'react';
import './UpdatePassword.css'
function UpdatePassword()
{

    const [updateDTO,setUpdateDTO ] = useState(
        {
            "id":0,
            "newPassword":""
        }
    );
    // const [password,setPassword] = useState("");
    // const [newPassword,setnewPassword] = useState("");



    const clear=()=>
    {
        document.getElementById('new-password').value="";
        document.getElementById('new-password-re-enter').value="";
        document.getElementById('error-validation').innerHTML="";
    }

    const CallUpdatePassword=()=>
    {   
        sessionStorage.setItem("Id",1);
        var password = document.getElementById('new-password').value
        var reEnterPassword = document.getElementById('new-password-re-enter').value

        if(password === reEnterPassword)
        {
            document.getElementById('error-validation').innerHTML="";
            setUpdateDTO({...updateDTO,"id":sessionStorage.getItem("Id"),"password":password})
            updateDTO.newPassword = password;
            updateDTO.id = Number(sessionStorage.getItem("Id"));
            console.log(updateDTO)
            userUpdatePassword();
        }
        else{
            document.getElementById('error-validation').innerHTML="Matchword miss match";
        }
    }

    const userUpdatePassword = () => {
        fetch('http://localhost:5199/api/User/UpdatePassword', {
          "method": 'PUT',
          "headers": {
            "accept": 'text/plain',
            'Content-Type': 'application/json',
            "Authorization": 'Bearer ' + sessionStorage.getItem('token')
          },
          "body": JSON.stringify(updateDTO),
        })
          .then((data) => {
            if (data.status === 202) {
                document.getElementById('error-validation').innerHTML="Password  Updated Sucessfully";

            } else {
                document.getElementById('error-validation').innerHTML="Unable to Update";

            }
          })
          .catch((err) => {
            console.log(err);
          });
      };





    return(
    <div className='update-password'>
        <div className='update-password-box'>
          <div className='update-container'>
          <h2>
                Update password
            </h2>
            <hr/>
            <input type='text' id='new-password'  className="login-email"  placeholder='Enter your New Password' />
        
            <input type='password' id='new-password-re-enter' className="login-password"  placeholder='Re Enter your Password'/> 

            <div className='btn'>

                <button className='update-btn' onClick={CallUpdatePassword}> Update Password </button> 
                <button className='clear-btn'  onClick={clear}> Cancel </button> 

            </div>
            <span id='error-validation'></span>
          </div>
        </div>
    </div>
    );
}

export default UpdatePassword;