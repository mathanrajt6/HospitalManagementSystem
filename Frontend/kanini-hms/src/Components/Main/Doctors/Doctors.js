import { useEffect, useMemo, useState } from 'react';
import Doctor from '../Doctor/Doctor';
import './Doctors.css'
function Doctors(prop)
{

    const [doctors,setDoctors]= useState([]);
    const[doctorStatus,setDoctorStatus] = useState(
        {
            "status":""
        }
    )

    const[doctorActiveStatus,setDoctorActiveStatus] = useState(
        {
            "active":""
        }
    )
  
 

      useEffect(()=>
      {
        sessionStorage.setItem('role',"admin")
        sessionStorage.setItem('YOUR_TOKEN','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMCIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTY4ODI4NzcwOCwiZXhwIjoxNjg4Mzc0MTA4LCJpYXQiOjE2ODgyODc3MDh9.d_465EX7iBUA_w5G1yAoLYWgQNBrdW0vf49twvzXGbM')
        if(sessionStorage.getItem('role')==="admin")
        {
           adminGetAll();
        }
        else{
            patinetGetAll();
        }
      }, []);



      const patinetGetAll=()=>
      {
        fetch('http://localhost:5199/api/Patient/GetAllDoctor',{
                "method":"GET",
                "headers":
                {
                    "accept": "text/plain",
                    "Content-Type": 'application/json',
                    "Authorization": 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4Iiwicm9sZSI6InBhdGllbnQiLCJuYmYiOjE2ODgyODY5NzIsImV4cCI6MTY4ODM3MzM3MiwiaWF0IjoxNjg4Mjg2OTcyfQ.5e0KOZsWKwrkmm98fKOzuyK9wRmjPDcpugC9EUYirPA'
    
                }}
            ).then(async (data)=>
            {
                var exInterns = await data.json()
                console.log(exInterns)
                setDoctors(exInterns)
                
            }
            ).catch((err)=>
            {
            console.log(err.error)
            }
            )
      }


      const adminGetAll=()=>
      {
        fetch('http://localhost:5199/api/Admin/GetAllDoctor',{
            "method":"GET",
            "headers":
            {
                "accept": "text/plain",
                "Content-Type": 'application/json',
                "Authorization": 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMCIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTY4ODI4NzcwOCwiZXhwIjoxNjg4Mzc0MTA4LCJpYXQiOjE2ODgyODc3MDh9.d_465EX7iBUA_w5G1yAoLYWgQNBrdW0vf49twvzXGbM'

            }}
        ).then(async (data)=>
        {
            var exInterns = await data.json()
            console.log(exInterns)
            setDoctors(exInterns)
        }
        ).catch((err)=>
        {
        console.log(err.error)
        }
        )
      }


      const filter = () => {
        console.log(doctorStatus);
        setDoctors([]);
        fetch('http://localhost:5199/api/Admin/GetAllDoctorGetAllDoctorBasedOnStatus', {
          "method": 'POST',
          "headers": {
            "accept": 'text/plain',
            'Content-Type': 'application/json',
            "Authorization": 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMCIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTY4ODI4NzcwOCwiZXhwIjoxNjg4Mzc0MTA4LCJpYXQiOjE2ODgyODc3MDh9.d_465EX7iBUA_w5G1yAoLYWgQNBrdW0vf49twvzXGbM'
          },
          "body": JSON.stringify(doctorStatus),
        })
          .then((data) => {
            if (data.status === 200) {
              return data.json();
            } else {
              return [];
            }
          })
          .then((exInterns) => {
            setDoctors(exInterns);
            console.log(exInterns); // Log the updated state value here
          })
          .catch((err) => {
            console.log(err);
          });
      };
      

    //   const filter=()=>
    //   {
    //     console.log(doctorStatus);
    //     fetch('http://localhost:5199/api/Admin/GetAllDoctorGetAllDoctorBasedOnStatus',{
    //         "method":"POST",
    //         "headers":
    //         {
    //             "accept": "text/plain",
    //             "Content-Type": 'application/json',
    //             "Authorization": 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMCIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTY4ODI4NzcwOCwiZXhwIjoxNjg4Mzc0MTA4LCJpYXQiOjE2ODgyODc3MDh9.d_465EX7iBUA_w5G1yAoLYWgQNBrdW0vf49twvzXGbM'

    //         },
    //         "body":JSON.stringify(doctorStatus)
    //     }).then(async (data)=>
    //     {
    //         if(data.status == 200)
    //         {
    //             return data.json();
    //         }
    //         else
    //         {
    //            return [];
    //         }
           
            
    //     }
    //     ).then((exInterns) => {
    //         setDoctors(exInterns);
    //     console.log(doctors);

    //       })
    //     .catch((err)=>
    //     {
    //     console.log(err.error)
    //     }
    //     )
    //   }

      const adminfilter=(e)=>
      {
        switch (e.target.value) {
            case "1":
                adminGetAll();
              break;
            case "2":
                doctorStatus.status="approved";
                console.log(doctorStatus);
                filter();
              break;
            case "3":
                doctorStatus.status="pending";
                filter();
              break;
            case "4":
                doctorStatus.status="un-approved";
                filter();
              break;
            default:
                adminGetAll();
              break;
          }
      }


    //   const doctorPatientFilter=()=>
    //   {
    //     fetch('http://localhost:5199/api/Patient/GetAllDoctorBasedOnFilters',{
    //             "method":"POST",
    //             "headers":
    //             {
    //                 "accept": "text/plain",
    //                 "Content-Type": 'application/json',
    //                 "Authorization": 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4Iiwicm9sZSI6InBhdGllbnQiLCJuYmYiOjE2ODgyODY5NzIsImV4cCI6MTY4ODM3MzM3MiwiaWF0IjoxNjg4Mjg2OTcyfQ.5e0KOZsWKwrkmm98fKOzuyK9wRmjPDcpugC9EUYirPA'
    
    //             },
    //             "body":JSON.stringify(doctorActiveStatus)
    //         }
    //         ).then(async (data)=>
    //         {
    //             if(data.status == 200)
    //             {
    //                 return data.json();
    //             }
    //             else{
    //                 return [];
    //             }
    //         }
    //         ).then((exInterns) => {
    //             setDoctors(exInterns);
    //           })
    //         .catch((err)=>
    //         {
    //         console.log(err.error)
    //         }
    //         )
    //   }

    const doctorPatientFilter = () => {
        setDoctors([]); // Clear the state before making the API call
        fetch('http://localhost:5199/api/Patient/GetAllDoctorBasedOnFilters', {
          "method": 'POST',
          "headers": {
            "accept": 'text/plain',
            'Content-Type': 'application/json',
            "Authorization": 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4Iiwicm9sZSI6InBhdGllbnQiLCJuYmYiOjE2ODgyODY5NzIsImV4cCI6MTY4ODM3MzM3MiwiaWF0IjoxNjg4Mjg2OTcyfQ.5e0KOZsWKwrkmm98fKOzuyK9wRmjPDcpugC9EUYirPA'
          },
          "body": JSON.stringify(doctorActiveStatus),
        })
          .then((data) => {
            if (data.status === 200) {
              return data.json();
            } else {
              return [];
            }
          })
          .then((exInterns) => {
            setDoctors(exInterns);
          })
          .catch((err) => {
            console.log(err);
          });
      };
      

      const patientFilter=(e)=>
      {
        switch (e.target.value) {
            case "1":
                patinetGetAll();
              break;
            case "2":
                doctorActiveStatus.active = "active";
                console.log(doctorActiveStatus);
                doctorPatientFilter();
              break;
            case "3":
                doctorActiveStatus.active = "in-active";
                doctorPatientFilter();
              break;
            default:
                patinetGetAll();
              break;
          }
      }

      
    const [search, setSearch] = useState('');
  
    return(
        <div className='doctors'>
            <h1>
                Doctors Details
            </h1>
            <div className='doctor-search'>
                <input type='text'  value={search}
            onChange={(event)=>setSearch(event.target.value)}
            />

           {
            sessionStorage.getItem('role') === "admin"?
            <div className='admin-filter'>
                  <select  onChange={adminfilter} defaultValue={'DEFAULT'}>
                    <option  value="DEFAULT">All</option>
                    <option  value="2">Approved</option>
                    <option value="3" > Pending </option>
                    <option value="4"> Un Approved </option>
                </select>
            </div>
            :
            <div className='patient-filter'>
                 <select  onChange={patientFilter} defaultValue={'DEFAULT'}>
                    <option  value="1">All</option>
                    <option  value="2">Active</option>
                    <option value="3" > In-Active </option>
                </select>
            </div>
           }
            </div>
            <div className='doctors-container'>
            <div className='doctors-list'>
                    {
                        doctors==null  ||doctors.length === 0 ?
                            <p>Doctor is empty</p>
                        :
                        doctors.filter((doctor) =>
                        
                        search.trim() === '' || doctor.firstName.toLowerCase() === search.toLowerCase() || doctor.lastName.toLowerCase() === search.toLowerCase() ||
                        doctor.doctor.specialization.toLowerCase() === search.toLowerCase() || doctor.phoneNUmber.toLowerCase() === search.toLowerCase() || doctor.doctor.consultingFees == search 
                        
                      ).map((doctor, index) => {
                        
                       return( <Doctor key={index} doctor={doctor} triggerFilter={filter} />);
                      })
                      
                    }
               
                {/* {
                    doctors.map((doctor, index) => {
                        
                        return( <Doctor key={index} doctor={doctor} />);
                       })
            
                } */}
            </div>
            <div className='doctors-info'>
                    <div className='doctor-call'>
                            if you need a doctor urgently outside of medicenter opening hours,
                            call the phone number provided note that call only if urgent and emergency
                    </div>
                    <br/>
                    <div className='working-time'>
                        Monday to Saturday
                        10AM to 10PM
                        Sunday
                        10Am to 2PM
                    </div>
            </div>
            </div>
        </div>
    );

   
}

export default Doctors;