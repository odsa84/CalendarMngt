using CalendarMngt.Entidades;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CalendarMngt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[DisableCors]
    [EnableCors("AllowAll")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositorioAuth iRepositorioAuth;

        public AuthController(UserManager<ApplicationUser> userManager, IRepositorioAuth iRepositorioAuth)
        {
            this.iRepositorioAuth = iRepositorioAuth;
            this._userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(ELogin model)
        {
            EOutLogin eOutLogin = iRepositorioAuth.Login(model);

            if(eOutLogin == null)
            {
                var badResult = BadRequest(new { message = "Usuario y/o contraseña incorrectos" });
                return badResult;
            }

            return Ok(eOutLogin);
        }

       /* [HttpPost("login")]
        public async Task<ActionResult> Login(ELogin model)
        {
            var user = await this._userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }

            if (await this._userManager.CheckPasswordAsync(user, model.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:4200",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Username = user.UserName
                });
            }

            return Unauthorized();
        }*/
    }
}