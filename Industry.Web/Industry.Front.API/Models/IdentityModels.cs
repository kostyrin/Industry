﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Industry.Data.DataModel;
using Industry.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Pattern.Infrastructure;

namespace Industry.Front.API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static AuthDbContext Create()
        {
            return new AuthDbContext();
        }
    }

    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<AuthDbContext>
    {
        protected override void Seed(AuthDbContext context)
        {
            //try
            //{
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("User"))
                {
                    roleManager.Create(new IdentityRole("User"));
                }

                var user = new ApplicationUser();
                user.Email = "admin@ipositron.ru";
                user.UserName = "admin@ipositron.ru";

                var userResult = userManager.Create(user, "123456");

                if (userResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");

                    using (var db = new ERPContext())
                    {
                        User usr = db.Users.FirstOrDefault(u => u.Email == user.Email);
                        if (usr != null)
                        {
                            usr.GlobalUserId = user.Id;
                            usr.ObjectState = ObjectState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}

            //context.Users.Add(new ApplicationUser { Email = "abc@yahoo.com", Password = "Marlabs" });
            //context.SaveChanges();           
        }
    }
}