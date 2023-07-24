using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Appointments.Models
{
	public class DoctorsDbContext : IdentityDbContext<IdentityUser>
	{
		public DoctorsDbContext(DbContextOptions<DoctorsDbContext> options): base(options)
		{
		}

		public DbSet<DoctorsAppointment> DoctorsAppointments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

