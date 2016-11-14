namespace Ifrit.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ifrit.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ifrit.Models.ApplicationDbContext";
        }

        protected override void Seed(Ifrit.Models.ApplicationDbContext context)
        {
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

            ////-----������� ���������� �����
            //context.Roles.AddOrUpdate(r => r.Name,
            //    new IdentityRole { Name = "admin" },
            //    new IdentityRole { Name = "applicant" },
            //    new IdentityRole { Name = "employer" });
            ////-----���������� �����
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //string[] roleNames = { "admin", "applicant", "employer" };
            //IdentityResult result;
            //foreach (var role in roleNames)
            //{
            //    if (!RoleManager.RoleExists(role))
            //    {
            //        result = RoleManager.Create(new IdentityRole(role));
            //    }
            //}
            //�������� ����� � �������������(� ������� �� ������)
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //UserManager.AddToRole("e3226cbb-31a9-4b1a-8240-dde8da86ece6", "admin"); //������������� ������������ ����������� � ��������(Name) ����
        }
    }
}
