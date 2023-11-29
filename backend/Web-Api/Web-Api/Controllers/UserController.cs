using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Dto;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL userBLL;
        public UserController(IUserBLL userBLL)
        {
            this.userBLL = userBLL;
        }

        //Login User ---- any
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromForm] LoginDTO user)
        {
            try
            {
                // user bll me data bhejo
                var response = await userBLL.LoginUser(user);
                if (response != null)
                {
                    return Ok(response);
                }
                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(400, $"An error occured while login:{e.Message}");
            }
        }

        [HttpGet("getMyTokens")]
        public async Task<IActionResult> GetMyTokens()
        {
            try
            {
                //get my userID
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }
                // user bll me data bhejo
                var response = await userBLL.GetMyTokens(userId);
                if (response != null)
                {
                    return Ok(response);
                }
                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Could not fetch tokens:{e.Message}");
            }
        }

        //Get current logged in user
        private int GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            return 0;
        }



    }
}
