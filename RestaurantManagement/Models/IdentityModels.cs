﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RestaurantManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {       
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Entree> Entree { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Starter> Starter { get; set; }
        public DbSet<WaitingList> WaitingList { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
    }
}