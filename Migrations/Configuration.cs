namespace AplicationEPAC.Migrations
{
    using AplicationEPAC.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AplicationEPAC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AplicationEPAC.Models.ApplicationDbContext context)
        {
            string roleAdmin = "admin";
            string roleProfe = "professor";
            string roleAlum = "student";

            AddRole(context, roleAdmin);
            AddRole(context, roleProfe);
            AddRole(context, roleAlum);

            AddUser(context, "admin", "admin", "admin@upm.es", roleAdmin);
            AddUser(context, "profesor1", "surname", "profesor1@upm.es", roleProfe);
            AddUser(context, "profesor2", "surname", "profesor2@upm.es", roleProfe);
            AddUser(context, "student1", "surname", "student1@alumnos.upm.es", roleAlum);
            AddUser(context, "student2", "surname", "student2@alumnos.upm.es", roleAlum);
            AddUser(context, "student3", "surname", "student3@alumnos.upm.es", roleAlum);
        }

        public void AddRole(ApplicationDbContext context, String role)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);
            if (!roleMgr.RoleExists(role))
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
        }

        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String role)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new
            UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Name = name,
                Surname = surname,
                UserName = email,
                Email = email,
            };
            // Es imprescindible que NO se cambie la contraseña para que los profesores
            // puedan probar la práctica con esta misma
            IdUserResult = userMgr.Create(appUser, "123456Aa!");
            // Asociar usuario con role
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
    }
}
