import { Navigate } from "react-router-dom";
import Doctors from "../Main/Doctors/Doctors";

function AdminProtected({role,children})
{
    
    if(role != null && (role === 'admin' || role === 'patient'))
        return <Doctors/>;
    return <Navigate to="/"/>;
}

export default AdminProtected;