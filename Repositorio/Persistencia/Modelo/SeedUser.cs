using CalendarMngt.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    public class SeedUser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new cita_doctorContext(
                serviceProvider.GetRequiredService <DbContextOptions<cita_doctorContext>>()))
            {
                if(!context.Users.Any())
                {
                    var user = new ApplicationUser()
                    {
                        Email = "odsa84@gmail.com",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = "odsa84",
                        PasswordHash = Hash.Crear("123456789", "jor290714luc300617")
                    };

                    context.Users.Add(user);

                    context.SaveChanges();
                }
            }
        }
    }
}
