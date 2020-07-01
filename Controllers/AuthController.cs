using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EAuth;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

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
        public IActionResult Login(ELogin eLogin)
        {
            EOutLogin eOutLogin = iRepositorioAuth.Login(eLogin);

            if(eOutLogin == null)
            {
                var badResult = BadRequest(new { message = "Usuario y/o contraseña incorrectos" });
                return badResult;
            }

            return Ok(eOutLogin);
        }

        [HttpPost]
        [Route("loginDoctor")]
        public IActionResult LoginDoctor(ELogin eLogin)
        {
            EOutDoctorLogin eOutLogin = iRepositorioAuth.LoginDoctor(eLogin);

            if (eOutLogin == null)
            {
                var badResult = BadRequest(new { message = "Usuario y/o contraseña incorrectos" });
                return badResult;
            }

            return Ok(eOutLogin);
        }

        [HttpPost]
        [Route("loginCliente")]
        public IActionResult LoginCliente(ELogin eLogin)
        {
            EOutClienteLogin eOutLogin = iRepositorioAuth.LoginCliente(eLogin);

            if (eOutLogin == null)
            {
                var badResult = BadRequest(new { message = "Usuario y/o contraseña incorrectos" });
                return badResult;
            }

            return Ok(eOutLogin);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("changePasswordSistema")]
        public ERespuestaCliente ChangePasswordSistema(ELogin eLogin)
        {
            ERespuestaCliente result = iRepositorioAuth.ChangePassword(eLogin);

            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("changePasswordPaciente")]
        public ERespuestaCliente ChangePasswordPaciente(EChangePassword eChange)
        {
            ERespuestaCliente result = iRepositorioAuth.ChangePasswordPaciente(eChange);

            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sendEmail")]
        public EError SendEmail(EInSendEmail entrada)
        {
            EError error = iRepositorioAuth.SendEmail(entrada.ToEmail, entrada.BodyEmail);

            return error;
        }

        private ERespuestaClienteLogin ValidarRespuesta(ERespuestaClienteLogin result)
        {
            if (result.Cliente == null)
            {
                result.Error.Codigo = "01";
                result.Error.Mensaje = "No se encontraron datos en la base";
            }
            else
            {
                result.Error.Codigo = "00";
                result.Error.Mensaje = "Ok";
            }

            return result;
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