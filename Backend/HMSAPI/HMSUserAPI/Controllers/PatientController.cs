using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;
using HMSUserAPI.Models.Error;
using HMSUserAPI.Models.Logger;
using HMSUserAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HMSUserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class PatientController : ControllerBase
    {
        private readonly ICustomLogger _customLogger;
        private readonly IPatientAction _patientAction;

        public PatientController( IPatientAction patientAction,ICustomLogger customLogger)
        {
            _customLogger = customLogger;
            _patientAction = patientAction;
        }


        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        public async Task<ActionResult<UserDTO>> PatientRegister(User user)
        {
            try
            {
                if(user.Id != 0)
                {
                    return BadRequest(new Error(400, ResponseMsg.Messages[10]));
                }
                var result = await _patientAction.PatientRegister(user);
                if (result != null)
                {
                    return Created("patient", result);
                }
                return BadRequest();
            }
            catch (UserException ue)
            {
                _customLogger.WriteLog(ue.Message);
                return BadRequest(new Error(400, ue.Message));
            }
            catch (ContextException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ce.Message));
            }
            catch (SqlException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[1]));
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[0]));
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<DoctorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "patient,admin")]
        public async Task<ActionResult<List<DoctorDTO>>> GetAllDoctor()
        {
            try
            {
                var result = await _patientAction.GetAllDoctor();
                if (result != null && result.Count != 0)
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[9]));
            }
            catch (ContextException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ce.Message));
            }
            catch (SqlException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[1]));
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[0]));
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<DoctorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [Authorize(Roles = "patient,admin")]

        public async Task<ActionResult<List<DoctorDTO>>> GetAllDoctorBasedOnFilters(DoctorFilterDTO doctorFilterDTO)
        {
            try
            {
                var result = await _patientAction.GetAllDoctorBasedOnFilters(doctorFilterDTO);
                if (result != null && result.Count != 0)
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[9]));
            }
            catch (ContextException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ce.Message));
            }
            catch (SqlException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[1]));
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[0]));
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [Authorize(Roles = "patient")]

        public async Task<ActionResult> UpdatePatientDetails(PatientUpdateDTO patientUpdateDTO )
        {
            try
            {
                var result = await _patientAction.UpdatePatientDetails(patientUpdateDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return NotFound(new Error(404, ResponseMsg.Messages[8]));
            }
            catch (ContextException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ce.Message));
            }
            catch (SqlException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[1]));
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[0]));
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [Authorize(Roles = "patient")]

        public async Task<ActionResult<PatientDTO>> GetPatientDetails(UserDTO userDTO)
        {
            try
            {
                var result = await _patientAction.GetPatientDetail(userDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[4]));
            }
            catch (ContextException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ce.Message));
            }
            catch (SqlException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[1]));
            }
            catch (Exception e)
            {
                _customLogger.WriteLog(e.Message);
                return BadRequest(new Error(400, ResponseMsg.Messages[0]));
            }
        }
    }
}
