using Microsoft.AspNetCore.Mvc;
using ComputergyAPI.Helpers;
using Microsoft.AspNetCore.Http;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(new { Message = "No file uploaded." });

                var allowedExtensions = ".jpg.jpeg.png";

                var uploadedFileName = await FileHelper.UploadFileAsync(file, allowedExtensions);

                return Ok(new
                {
                    Message = "Image uploaded successfully!",
                    FileName = uploadedFileName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }
    }
}


//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace ComputergyAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PasswordController : ControllerBase
//    {
//        [HttpPost("hash")]
//        public IActionResult HashPassword([FromBody] PassInput input)
//        {
//            if (string.IsNullOrEmpty(input.Password))
//                return BadRequest("Password is required.");

//            var hashed = PasswordHasher.HashPassword(input.Password);
//            return Ok(new { HashedPassword = hashed });
//        }

//        [HttpPost("verify")]
//        public IActionResult VerifyPassword([FromBody] PassInput input)
//        {
//            if (string.IsNullOrEmpty(input.Password) || string.IsNullOrEmpty(input.HashedPassword))
//                return BadRequest("Password and HashedPassword are required.");

//            var isMatch = PasswordHasher.VerifyPassword(input.Password, input.HashedPassword);
//            return Ok(new { IsMatch = isMatch });
//        }
//    }
//}