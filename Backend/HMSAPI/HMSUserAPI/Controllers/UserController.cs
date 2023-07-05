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
    public class UserController : ControllerBase
    {
        private readonly ICustomLogger _customLogger;
        private readonly IUserAction _userAction;

        public UserController(IUserAction userAction,ICustomLogger customLogger)
        {
            _customLogger = customLogger;
            _userAction = userAction;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ResultFIlter]

        public async Task<ActionResult<UserDTO>> Login(UserDTO userDTO)
        {
            try
            {
                var result = await _userAction.Login(userDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new Error(404, ResponseMsg.Messages[7]));
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
        [Authorize]
        public async Task<ActionResult> UpdatePassword(UserPasswordUpdateDTO userPasswordUpdateDTO)
        {
            try
            {
                var result = await _userAction.PasswordUpdate(userPasswordUpdateDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return NotFound(new Error(404, ResponseMsg.Messages[2]));
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



    }
}
