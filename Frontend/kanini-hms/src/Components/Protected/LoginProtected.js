import { Navigate } from "react-router-dom";

function LoginProtected({role,children})
{

    if(role == null || role === "")
    {
        if(role === 'doctor' )
        {
            if(sessionStorage.getItem('doctorStatus').toLowerCase() === "approved")
                return children;
            if(sessionStorage.getItem('doctorStatus').toLowerCase() === "pending")  
                return <Navigate to="/pending"/>;
            if(sessionStorage.getItem('doctorStatus').toLowerCase() === "un-approved")  
                return <Navigate to="/un-approved"/>;
        }  
        return children;
    }
    return <Navigate to="/"/>;
}

export default LoginProtected;