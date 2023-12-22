using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using UTEI.Dtos.AuthenticationDtos;
using UTEI.Models.AuthenticationModel;

namespace UTEI.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("roles/add")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var appRole = new ApplicationRole { Name = request.Role };
            var createRole = await _roleManager.CreateAsync(appRole);

            return Ok(new { message = "role created succesfully" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var result = await RegisterAsync(request);

                if (result.Success)
                {
                    // Generate verification token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(result.User);

                    // Send verification email
                    await SendVerificationEmail(result.User.Email, token);

                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        private async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var userExists = await _userManager.FindByEmailAsync(request.Email);
                Console.WriteLine("HERE", userExists);
                if (userExists != null) return new RegisterResponse { Message = "User already exists", Success = false };
                //if we get here, no user with this email..

                userExists = new ApplicationUser
                {
                    Name = request.Name,
                    Email = request.Email,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    UserName = request.Email,

                };
                var createUserResult = await _userManager.CreateAsync(userExists, request.Password);
                if (!createUserResult.Succeeded) return new RegisterResponse { Message = $"Create user failed {createUserResult?.Errors?.First()?.Description}", Success = false };
                //user is created...
                //then add user to a role...
                var addUserToRoleResult = await _userManager.AddToRoleAsync(userExists, "USER");
                if (!addUserToRoleResult.Succeeded) return new RegisterResponse { Message = $"Create user succeeded but could not add user to role {addUserToRoleResult?.Errors?.First()?.Description}", Success = false };

                //all is still well..
                return new RegisterResponse
                {
                    Success = true,
                    Message = "User registered successfully. Please verify your email.",
                    User = userExists
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("OR HERE");
                return new RegisterResponse { Message = ex.Message, Success = false };
            }
        }

        [HttpGet]
        [Route("verify-email")]
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Redirect("http://localhost:3000/login");
            }
            else
            {
                return Redirect("http://localhost:3000/signup");
            }
        }

        private async Task SendVerificationEmail(string email, string token)
        {
            // Construct the verification link with the token
            var verificationLink = Url.Action("VerifyEmail", "Authentication", new { email, token }, Request.Scheme);

            // Set up SMTP client configuration
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587; // Specify the SMTP port
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("3jandeco3@gmail.com", "iajbdwiioujjroca");
                client.EnableSsl = true; // Enable SSL if required

                // Create and configure the email message
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("3jandeco3@gmail.com", "UTEI");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Verify your email address";
                mailMessage.Body = $"Please <a href='{verificationLink}'>click here</a> to verify your email.";
                mailMessage.IsBodyHtml = true;

                // Send the email
                await client.SendMailAsync(mailMessage);
            }
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await LoginAsync(request);

            return result.Success ? Ok(result) : BadRequest(result.Message);


        }

        private async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null)
                {
                    return new LoginResponse { Message = "Invalid email/password", Success = false };
                }

                // Check if the user's email is verified
                if (!user.EmailConfirmed)
                {
                    return new LoginResponse { Message = "Email not verified. Please verify your email to login.", Success = false };
                }

                // Validate password
                var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isValidPassword)
                {
                    return new LoginResponse { Message = "Invalid email/password", Success = false };
                }

                // Generate token upon successful password verification
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                // Create JWT token and return login response
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1swek3u4uo2u4a6e"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddMinutes(30);

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new LoginResponse
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Login Successful",
                    Email = user?.Email,
                    Success = true,
                    UserId = user?.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new LoginResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

