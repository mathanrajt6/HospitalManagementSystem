using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;
using HMSUserAPI.Models.Error;
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
    public class DoctorController : ControllerBase
    {
        private readonly ICustomLogger _customLogger;
        private readonly IDoctorAction _doctorAction;

        public DoctorController( IDoctorAction doctorAction,ICustomLogger customLogger)
        {
            _customLogger = customLogger;
            _doctorAction = doctorAction;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ResultFIlter]
        public async Task<ActionResult<UserDTO>> DoctorRegister(User user)
        {
            try
            {
                if (user.Id != 0)
                {
                    return BadRequest(new Error(400, ResponseMsg.Messages[10]));
                }
                var result = await _doctorAction.DoctorRegister(user);
                if (result != null)
                {
                    return Created("doctor",result);
                }
                return BadRequest(new Error(400, ResponseMsg.Messages[11]));
            }
            catch(UserException ue)
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
        [ProducesResponseType(typeof(List<PatientDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResultFIlter]
        [Authorize(Roles = "doctor,admin")]
        public async Task<ActionResult<List<PatientDTO>>> GetAllPatient()
        {
            try
            {
                var result = await _doctorAction.GetAllPatient();
                if (result != null && result.Count != 0)
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[8]));
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



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ResultFIlter]
        [Authorize(Roles = "doctor")]

        public async Task<ActionResult> ToggleActiveStatus(DoctorFilterDTO doctorFilterDTO)
        {
            try
            {
                var result = await _doctorAction.ToggleActive(doctorFilterDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return NotFound(new Error(404, ResponseMsg.Messages[3]));
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
        [ResultFIlter]
        [Authorize(Roles = "doctor")]

        public async Task<ActionResult> UpdateDoctorDetails(DoctorUpdateDTO doctorUpdateDTO)
        {
            try
            {
                var result = await _doctorAction.UpdateDoctorDetails(doctorUpdateDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return NotFound(new Error(404, ResponseMsg.Messages[3]));
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
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ResultFIlter]
        [Authorize(Roles = "doctor")]

        public async Task<ActionResult<DoctorDTO>> GetDoctorDetails(UserDTO userDTO)
        {
            try
            {
                var result = await _doctorAction.GetDoctorDetails(userDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[3]));
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
