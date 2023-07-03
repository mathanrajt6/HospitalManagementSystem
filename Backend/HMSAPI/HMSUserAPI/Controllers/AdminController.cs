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
    public class AdminController : ControllerBase
    {
        private readonly ICustomLogger _customLogger;
        private readonly IAdminAction _adminAction;

        public AdminController( IAdminAction adminAction,ICustomLogger logger)
        {
            _customLogger = logger;
            _adminAction = adminAction;
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> ChangeDoctorStatus(DoctorApproveDTO doctorApproveDTO)
        {
            try
            {
                var result = await _adminAction.ChangeApproveStatus(doctorApproveDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return NotFound(new Error(404, ResponseMsg.Messages[3]));
            }
            catch(ContextException ce)
            {
                _customLogger.WriteLog(ce.Message);
                return BadRequest(new Error(400, ce.Message));
            }
            catch(SqlException ce)
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
        [ProducesResponseType(typeof(List<DoctorDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<DoctorDTO>>> GetAllDoctorGetAllDoctorBasedOnStatus(DoctorFilterDTO doctorFilterDTO)
        {
            try
            {
                var result = await _adminAction.GetAllDoctorBasedOnStatus(doctorFilterDTO);
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

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(UserDetailDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDetailDTO>> GetAdminDetails(UserDTO userDTO)
        {
            try
            {
                var result = await _adminAction.GetUserDetailDetail(userDTO);
                if (result != null )
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[2]));
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

        [Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<DoctorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<DoctorDTO>>> GetAllDoctor()
        {
            try
            {
                var result = await _adminAction.GetAllDoctor();
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
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateAdminDetails(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var result = await _adminAction.UpdateAdminDetails(userUpdateDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return NotFound(new Error(404, ResponseMsg.Messages[2]));
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
