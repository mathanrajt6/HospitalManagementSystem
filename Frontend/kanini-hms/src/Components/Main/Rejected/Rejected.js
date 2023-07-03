import { Link } from 'react-router-dom';
import './Rejected.css'
function Rejected()
{
    return(
        <div className='rejected'>
            <div className="application-status">
            <div className='reject-logo'>
            <div className="sad-smiley">
            <i className="bi bi-emoji-frown"></i>
        </div>

            </div>
            <h1>Your Application has been Rejected</h1>
            <p>We're sorry to inform you that your application has been rejected. Please try again later. If you have any queries, please contact our team.</p>
            <div className='home-link-back'>
                <Link  to='/home/'>Go to Home Page</Link>
            </div>
            </div>

        </div>
    )
}
export default Rejected;