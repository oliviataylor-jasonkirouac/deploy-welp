namespace deploy.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<deploy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(deploy.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(deploy.Models.ApplicationDbContext context)
        {
             AddUserAndRole(context);
            context.Users.AddOrUpdate(b => b.UserName);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.BusinessTypes.AddOrUpdate(
                b => b.BusinessTypeID,
                new Models.BusinessType { BusinessTypeID = 1, BusinessTypeName = "Restaurant" },
               new Models.BusinessType { BusinessTypeID = 2, BusinessTypeName = "Shopping" }
               );
            context.Businesses.AddOrUpdate(
              b => b.BusinessName,
             new Models.Business { BusinessName = "McDonalds", BusinessTypeID = 1 },
             new Models.Business { BusinessName = "Chipotle", BusinessTypeID = 1 }
            );
        }
    }
}
