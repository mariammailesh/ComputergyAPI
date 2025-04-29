using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ComputergyAPI.Controllers.AuthenticationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthanication _authenticationService;

        public AuthenticationController(IAuthanication authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpInputDTO input)
        {
            try
            {
                var token = await _authenticationService.SignUp(input);
                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInInputDTO input)
        {
            try
            {
                var token = await _authenticationService.SignIn(input);

                if (string.IsNullOrEmpty(token) || token == "User not found")
                    return Unauthorized(new { message = "Invalid credentials." });

                return Ok(new { token = token });
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Verification(VerificationInputDTO input)
        {
            try
            {
                var response = await _authenticationService.Verification(input);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendOTP(string email)
        {
            try
            {
                var response = await _authenticationService.SendOTP(email);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            try
            {
                var response = await _authenticationService.ResetPersonPassword(input);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignOut(int userId)
        {
            try
            {
                var response = await _authenticationService.SignOut(userId);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
