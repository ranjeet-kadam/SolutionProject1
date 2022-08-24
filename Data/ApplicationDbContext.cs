using EChallan1.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EChallan1.Web.Data
{
    
    
        public class ApplicationDbContext :IdentityDbContext
        {

            public DbSet<Challan> Challans { get; set; }

            public DbSet<ChallanDetail> ChallanDetails { get; set; }
            public DbSet<Issue> Issue { get; set; }

            public DbSet<PaymentMethod> PaymentMethod { get; set; }

            public DbSet<Customer> Customer { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
        }
}
