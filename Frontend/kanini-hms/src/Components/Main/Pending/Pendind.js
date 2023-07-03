import { Link } from 'react-router-dom';
import './Pending.css'
function Pending()
{
    return(
        <div className='pending'>
            <div className="application-status">
            <div className='loading'>
                <div className="loading-logo"></div>
            </div>
            <h1>Your Application is in Progress</h1>
            <p>Once approved, we will notify you via email. Thank you!</p>
            </div>
            <div className='home-back-link'> 
            <Link to='/home/'>Go to Home Page</Link>
            </div>
        </div>
    )
}
export default Pending;