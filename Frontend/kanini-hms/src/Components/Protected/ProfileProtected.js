import { Navigate } from "react-router-dom";

function ProfileProtected({role,children})
{
    
    if(role != null && (role === 'admin' || role === 'patient' || role==='doctor') )
        return children;
    return <Navigate to="/"/>;
}

export default ProfileProtected;