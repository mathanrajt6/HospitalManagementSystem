import { Navigate } from "react-router-dom";

function AdminProtected({role,children})
{
    if(role === 'admin' || role === 'patient')
        return children;
    return <Navigate to="/"/>;
}

export default AdminProtected;