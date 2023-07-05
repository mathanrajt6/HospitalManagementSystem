import { useEffect, useState } from 'react';
import './Doctor.css';
import male from '../../../Asset/male.png';
import female from '../../../Asset/female.png';
import { toast } from 'react-toastify';
function Doctor(prop)
{
    const[doctor,setDoctor]=useState(prop.doctor);
    // "userDetailID": 0,
    // "firstName": "string",
    // "lastName": "string",
    // "email": "string",
    // "age": 0,
    // "dateOfBirth": "2023-07-02T07:36:33.775Z",
    // "phoneNUmber": "string",
    // "address": "string",
    // "gender": "string",
    // "doctor": {
    //   "doctorID": 0,
    //   "consultingFees": 0,
    //   "specialization": "string",
    //   "yearOfExperience": 0,
    //   "approvedStatus": "string",
    //   "active": "string"
    const [adminApprove,setAdminAprove]= useState(
        {
            "id":0,
            "status":""
        }
    );

    const doctorChangeStatus =()=>
      {
        console.log(adminApprove);
        fetch('http://localhost:5199/api/Admin/ChangeDoctorStatus',{
            "method":"PUT",
            "headers":
            {
                "accept": "text/plain",
                "Content-Type": 'application/json',
                "Authorization": 'Bearer ' + sessionStorage.getItem('token')
            },
            "body":JSON.stringify(adminApprove)}
        ).then(async (data)=>
        {
            if(data.status === 202)
            {
                popbefore();
                toast.success('Doctor Status Updated Sucessfully!', {
                    position: toast.POSITION.BOTTOM_RIGHT
                });
                
            }
            else
            {
                toast.error('Unable to Updated Doctor status!', {
                    position: toast.POSITION.BOTTOM_RIGHT
                });
                console.log( await data.json())

            }
        }
        ).catch((err)=>
        {
        console.log(err.error)
        }
        )
      }

      const popbefore=()=>
      {
          prop.triggerFilter();
      }
    return(
        
        <div className="doctor">
            <div className="doctor-profile">
                <div className="doctor-profile-container">
                    <div className='doctor-profile-image'>
                        <img width='200' height='200' src={doctor.gender=="male" ? male : female}/>
                    </div>
                   <span className="doctor-name">{"DR "+doctor.firstName +" "+doctor.lastName}</span>
                   {/* <span className='drop-down-menu' > <i className="bi bi-chevron-double-down"></i> </span> */}

                    
                </div>
            </div>
            <div className="doctor-content">
                <div className="doctor-content-container">
                    <div className={doctor.doctor.active == "in-active" ? "red-font" : "green-font"}>
                            {doctor.doctor.active}
                    </div> 
                    <span className="doctor-specialization">
                        Specialization  :  {doctor.doctor.specialization}
                    </span>
                    <span className="year-of-experinece">
                            Year of Experince : {doctor.doctor.yearOfExperience}
                    </span>
                    <span className="consulting-fee">
                            Consulting-fees : {doctor.doctor.consultingFees}
                    </span>
                    <span className="phone-number">
                            Phone Number : {doctor.phoneNUmber}
                    </span>
                  {sessionStorage.getItem('role')==="admin" ?
                      (
                        (doctor.doctor.approvedStatus === "pending" ?
                                    (
                                    <div className='admin-function'>
                                        <button onClick={()=>{
                                            setAdminAprove({...adminApprove,"id":doctor.userDetailID,"status":"approved"});
                                            adminApprove.id= doctor.userDetailID;
                                            adminApprove.status = "approved";
                                            doctorChangeStatus();
                                            

                                        }}
                                        ><i className="bi bi-check-circle"></i></button>
                                        <button
                                            onClick={(event)=>{
                                            setAdminAprove({...adminApprove,"id":doctor.userDetailID,"status":"un-approved"});
                                            adminApprove.id= doctor.userDetailID;
                                            adminApprove.status = "un-approved";
                                            doctorChangeStatus();
                                        }}
                                        ><i className="bi bi-x-circle"></i></button>
                                    </div>
                                )
                                :(
                                    <div className='admin-function'>
                                        {doctor.doctor.approvedStatus}
                                    </div>
                                )
                            )
                               
                      
                      )
                    :
                    (
                        <div>

                        </div>
                    )
                    
                       
                    
                    }
                
                </div>
                
            </div>
            <br/>
        </div>
    );
}

export default Doctor;