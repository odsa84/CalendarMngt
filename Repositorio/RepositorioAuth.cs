using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EAuth;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using CalendarMngt.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioAuth : IRepositorioAuth
    {
        private readonly IMapper _mapper;
        public RepositorioAuth(IMapper _mapper)
        {
            this._mapper = _mapper;
        }
        public EOutLogin Login(ELogin eLogin)
        {
            EOutLogin eOutLogin = null;
            using (var context = new cita_doctorContext())
            {
                string pass = Hash.Crear(eLogin.Password, "jor290714luc300617");

                var user = (from us in context.Users
                    .Where(us => (us.Email.Equals(eLogin.Username) && us.PasswordHash.Equals(pass)))
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
                    expires: DateTime.Now.AddMinutes(1440),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                eOutLogin = new EOutLogin()
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Usuario = user.ToList()[0],
                    Tipo = "owner"
                };

                return eOutLogin;
            }
        }

        public EOutDoctorLogin LoginDoctor(ELogin eLogin)
        {
            EOutDoctorLogin eOutDoctorLogin = null;
            using (var context = new cita_doctorContext())
            {
                string pass = Hash.Crear(eLogin.Password, "jor290714luc300617");

                var doctor = (from ilDoctore in context.Doctor
                    .Where(doc => (doc.Email.Equals(eLogin.Username) && doc.Password.Equals(pass)))
                            select ilDoctore);

                if (doctor.ToList().Count == 0)
                {
                    return eOutDoctorLogin;
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:4200",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(1440),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                eOutDoctorLogin = new EOutDoctorLogin()
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Doctor = _mapper.Map<EOutDoctor>(doctor.ToList()[0]),
                    Tipo = "doctor"
                };

                return eOutDoctorLogin;
            }
        }

        public EOutClienteLogin LoginCliente(ELogin eLogin)
        {
            EOutClienteLogin eOutClienteLogin = null;
            using (var context = new cita_doctorContext())
            {
                string pass = Hash.Crear(eLogin.Password, "jor290714luc300617");

                var cliente = (from cli in context.Cliente
                    .Where(c => (c.Email.Equals(eLogin.Username) && c.Password.Equals(pass)))
                              select cli);

                if (cliente.ToList().Count == 0)
                {
                    return eOutClienteLogin;
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:4200",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(1440),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                eOutClienteLogin = new EOutClienteLogin()
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Cliente = _mapper.Map<EOutCliente>(cliente.ToList()[0]),
                    Tipo = "client"
                };

                return eOutClienteLogin;
            }
        }

        public ERespuestaCliente ChangePassword(ELogin eLogin)
        {
            ERespuestaCliente eRespuesta = new ERespuestaCliente();
            using (var context = new cita_doctorContext())
            {
                string pass = Hash.Crear(eLogin.Password, "jor290714luc300617");

                var cliente = (from cli in context.Cliente
                    .Where(c => (c.Email.Equals(eLogin.Username)))
                        select cli).FirstOrDefault();

                cliente.Password = pass;

                try
                {
                    context.SaveChanges();
                    eRespuesta.Error.Codigo = "00";
                    eRespuesta.Error.Mensaje = "Ok";
                }
                catch (Exception e)
                {
                    eRespuesta.Error.Codigo = "01";
                    eRespuesta.Error.Mensaje = e.Message;                    
                }

                return eRespuesta;
            }
        }

        public ERespuestaCliente ChangePasswordPaciente(EChangePassword eChange)
        {
            ERespuestaCliente eRespuesta = new ERespuestaCliente();
            using (var context = new cita_doctorContext())
            {
                string oldPass = Hash.Crear(eChange.OldPassword, "jor290714luc300617");
                string newPass = Hash.Crear(eChange.NewPassword, "jor290714luc300617");

                var cliente = (from cli in context.Cliente
                    .Where(c => (c.Email.Equals(eChange.Email) && c.Password.Equals(oldPass)))
                               select cli).FirstOrDefault();

                if(cliente != null)
                {
                    cliente.Password = newPass;

                    try
                    {
                        context.SaveChanges();
                        eRespuesta.Error.Codigo = "00";
                        eRespuesta.Error.Mensaje = "Ok";
                    }
                    catch (Exception e)
                    {
                        eRespuesta.Error.Codigo = "01";
                        eRespuesta.Error.Mensaje = e.Message;
                    }
                } else {
                    eRespuesta.Error.Codigo = "02";
                    eRespuesta.Error.Mensaje = "No se encontro el paciente con el usuario y contraseña proporcionados.";
                }                                

                return eRespuesta;
            }
        }

        public EError SendEmail(string toEmail, string bodyEmail)
        {
            MailAddress to = new MailAddress(toEmail);//"odsa84@gmail.com"
            MailAddress from = new MailAddress("odsa84@gmail.com");

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Cita Agendada";
            message.Body = bodyEmail;

            SmtpClient client = new SmtpClient("smtp.elasticemail.com", 2525)
            {
                Credentials = new NetworkCredential("odsa84@gmail.com", "6D1E3FA54E8A35A76E0DB79FDD0690138F98"),
                EnableSsl = true
            };
            
            EError error = new EError();
            try
            {
                client.Send(message);

                error.Codigo = "00";
                error.Mensaje = "Ok";
            }
            catch (SmtpException ex)
            {
                throw new SmtpException(ex.Message);
                /*error.Codigo = "01";
                error.Mensaje = ex.ToString();*/
            }

            return error;
        }
    }
}
