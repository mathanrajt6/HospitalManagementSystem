import { Navigate } from "react-router-dom";

function DoctorProtected({role,children})
{

    if(role!= null && role === 'doctor' )
    {
        if(sessionStorage.getItem('doctorStatus').toLowerCase() === "approved")
            return children;
        if(sessionStorage.getItem('doctorStatus').toLowerCase() === "pending")  
            return <Navigate to="/pending"/>;
        if(sessionStorage.getItem('doctorStatus').toLowerCase() === "un-approved")  
            return <Navigate to="/un-approved"/>;
    }  
    return <Navigate to="/"/>;
}

export default DoctorProtected;