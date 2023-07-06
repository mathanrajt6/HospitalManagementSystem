import { useEffect, useMemo, useState } from 'react';
import Doctor from '../Doctor/Doctor';
import './Doctors.css'


function Doctors(prop)
{

    const [doctors,setDoctors] = useState([]);
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
                    "Authorization": 'Bearer ' + sessionStorage.getItem('token')
    
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
                "Authorization": 'Bearer ' + sessionStorage.getItem('token')

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
            "Authorization": 'Bearer ' + sessionStorage.getItem('token')
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
            console.log(exInterns); 
          })
          .catch((err) => {
            console.log(err);
          });
      };
      


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


 

    const doctorPatientFilter = () => {
        setDoctors([]); 
        fetch('http://localhost:5199/api/Patient/GetAllDoctorBasedOnFilters', {
          "method": 'POST',
          "headers": {
            "accept": 'text/plain',
            'Content-Type': 'application/json',
            "Authorization": 'Bearer ' + sessionStorage.getItem('token')
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
            <hr/>
            <div className='doctor-search'>
            <div>
            <label><i class="bi bi-search"> </i> : </label>
                <input type='text'  value={search}
            onChange={(event)=>setSearch(event.target.value)}
            placeholder='Search Doctors' />
            </div>

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
              
            </div>
            <div className='doctors-info'>
                   
                    {sessionStorage.getItem('role')==='admin' ?
                    (<div className='admin-info'>
                      
                    <h1>KANINI HMS</h1>
                    <h2>Admin Instructions: Doctor Approval</h2>

                      <h3>Doctor Approval Process</h3>
                      <p>As an admin, your role is to review and approve doctor profiles before they are listed on the website. Follow these instructions to ensure a thorough and accurate approval process:</p>

                      <ol>
                        <li>
                          <h3>Review Application</h3>
                          <p>Upon receiving a doctor's application, carefully review all submitted information, including their qualifications, experience, and certifications.</p>
                        </li>

                        <li>
                          <h3>Verify Credentials</h3>
                          <p>Verify the authenticity of the doctor's credentials, such as medical degrees, licenses, and professional affiliations. Cross-reference the provided information with reliable sources or contact relevant authorities if necessary.</p>
                        </li>

                        <li>
                          <h3>Check References</h3>
                          <p>Contact the references provided by the doctor to validate their professional reputation and work history. Request additional references if needed to ensure a comprehensive evaluation.</p>
                        </li>

                        <li>
                          <h3>Interview the Doctor</h3>
                          <p>Conduct an interview with the doctor to assess their communication skills, professionalism, and alignment with the values and standards of our organization. Address any questions or concerns that arise during the interview.</p>
                        </li>

                        <li>
                          <h3>Finalize Approval Decision</h3>
                          <p>Based on your evaluation, make an informed decision on whether to approve or reject the doctor's application. Consider their qualifications, experience, references, and interview performance.</p>
                        </li>
                      </ol>

                      <p>Remember to maintain professionalism, confidentiality, and fairness throughout the approval process. Approve only those doctors who meet our criteria and demonstrate the necessary qualifications and expertise.</p>

                      <p>Thank you for your dedication and commitment to ensuring the highest standards in our network of doctors.</p>


                    </div>)
                    :
                    (<div className='patient-info'>
              <h1>KANINI HMS</h1>
              <h2>Urgent Doctor Contact Information</h2>

              <p>If you need a doctor urgently outside of Medicenter's opening hours, please call the phone number provided. However, please note that you should only make the call in cases of urgency and emergency situations.</p>

              <h3>Medicenter Opening Hours</h3>
              <p>
                Monday to Saturday: 10:00 AM to 10:00 PM<br/>
                Sunday: 10:00 AM to 2:00 PM
              </p>

              <p>For patients requiring immediate medical attention outside of these hours, please contact the emergency phone number provided below:</p>

              <h3>Emergency Phone Number</h3>
              <p>[Emergency Phone Number]</p>

              <p>It is important to emphasize that this emergency phone number should be used strictly for urgent and emergency situations. If your condition is not urgent or can wait until Medicenter reopens, we encourage you to seek medical attention during our regular operating hours.</p>

              <h3>Non-Urgent Inquiries</h3>
              <p>If you have any non-urgent medical inquiries or general questions, please contact us during Medicenter's regular operating hours. Our staff will be available to assist you and provide the necessary information.</p>

              <h3>Medical Advice</h3>
              <p>If you require medical advice but it is not an emergency, we recommend contacting your primary care physician or local medical helpline. They will be able to provide guidance and answer your non-urgent medical questions.</p>

              <p>Remember, it is important to prioritize emergency situations for the safety and well-being of all patients.</p>
                                </div>)
                }
            </div>
          </div>
        </div>
    );

   
}

export default Doctors;