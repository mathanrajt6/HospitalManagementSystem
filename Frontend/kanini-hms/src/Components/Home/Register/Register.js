import { Link } from 'react-router-dom';
import './Register.css'
function Register()
{
    return(
        <div className='register'>
        <div className='register-button'>
            <div className='register-button-box'>
                <button>
                    <Link to='/doctorRegister'>
                        Register As Doctor
                    </Link>
                </button>
                <button>
                    <Link to='/patientRegister'>
                        Register As Patient
                    </Link>
                </button>

            </div>
            
        </div>
        <div className='register-content'>


        </div>
    </div>
    );
}

export default Register;