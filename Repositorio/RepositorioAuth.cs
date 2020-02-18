using CalendarMngt.Entidades;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using CalendarMngt.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioAuth : IRepositorioAuth
    {
        public EOutLogin Login(ELogin model)
        {
            EOutLogin eOutLogin = null;
            using (var context = new cita_doctorContext())
            {
                string pass = Hash.Crear(model.Password, "jor290714luc300617");

                var user = (from us in context.Users
                    .Where(us => (us.UserName.Equals(model.Username) && us.PasswordHash.Equals(pass)))
                            select us);

                if (user.ToList().Count == 0)
                {
                    return eOutLogin;
                }

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

                eOutLogin = new EOutLogin()
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Usuario = user.ToList()[0]
                };

                return eOutLogin;
            }
        }
    }
}
