import { useEffect, useState } from 'react';
import './Patients.css'

function Patients()
{

    const [patients,setPatients]= useState([
    {
        "patient": {
        "patientID": 1,
        "emergencyContactName": "string",
        "emergencyContactPhone": "1236754795",
        "bloodGroup": "string"
        },
        "userDetailID": 1,
        "firstName": "string",
        "lastName": "string",
        "email": "stri@gmal.dng",
        "age": 20,
        "dateOfBirth": "2003-07-01T00:00:00",
        "phoneNUmber": "1236547861",
        "address": "string",
        "gender": "string"
    },
    ]);

    useEffect(()=>
    {
            fetch('http://localhost:5199/api/Doctor/GetAllPatient',{
                "method":"GET",
                "headers":
                {
                    "accept": "text/plain",
                    "Content-Type": 'application/json',
                    "Authorization": 'Bearer ' + sessionStorage.getItem('token')
    
                }}
        ).then(async (data)=>
        {
            var exInterns = await data.json()
            console.log(exInterns)
            setPatients(exInterns)
        }
        ).catch((err)=>
        {
        console.log(err.error)
        }
        )
    }, []);

    
    const [search,setsearch] = useState("");

//     const filteredPatients = patients.filter((patient) =>
//     patient.lastName.toLowerCase().includes(search.toLowerCase())
//   );

  const filteredPatients = patients.filter((patient) =>
    Object.values(patient)
      .join(' ')
      .toLowerCase()
      .includes(search.toLowerCase())
  );

    // const filter=()=>
    // {
    //     setPatients(
    //         patients.filter
    //     )
    // }
    return(
        <div className='patients'>
           <div className='patients-search'>
            <h2>
                Patient Details
            </h2>
            <hr/>
           <div className='patients-search-bar'>
            <label><i class="bi bi-search"> </i> : </label>
           <input placeholder='search patient' type='text' onChange={(event)=>{
                    setsearch(event.target.value);
            }}/>
           </div>
           </div>
            <div className='patients-table'>
                <table>
                    <thead>
                        <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Age</th>
                        <th>Gender</th>
                        <th>address</th>
                        <th>emergencyContactName</th>
                        <th>emergencyContactPhone</th>
                        </tr>
                        
                    </thead>
                    <tbody>
                        {
                        filteredPatients.map((patient,index)=>
                            {
                                return(
                                    <tr key={index}>
                                        <td>{patient.firstName +" "+ patient.lastName}</td>
                                        <td> {patient.email} </td>
                                        <td> {patient.phoneNUmber} </td>
                                        <td> {patient.age} </td>
                                        <td> {patient.gender} </td>
                                        <td> {patient.address}</td>
                                        <td> {patient.patient.emergencyContactName}</td>
                                        <td> {patient.patient.emergencyContactPhone}</td>

                                    </tr>
                                );
                            })
                        }
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default Patients;



   {/* patients.map((patient,index)=>
                            {
                                return(
                                    <tr key={index}>
                                        <td>{patient.firstName +" "+ patient.lastName}</td>
                                        <td> {patient.email} </td>
                                        <td> {patient.phoneNUmber} </td>
                                        <td> {patient.age} </td>
                                        <td> {patient.gender} </td>
                                        <td> {patient.address}</td>
                                        <td> {patient.patient.emergencyContactName}</td>
                                        <td> {patient.patient.emergencyContactPhone}</td>

                                    </tr>
                                );
                            }) */}  