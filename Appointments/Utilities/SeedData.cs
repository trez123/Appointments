using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Appointments.Utilities
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> usermanager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await SeedRoles(roleManager);
            await SeedDoctorUser(usermanager);
            await SeedEmployeeUser(usermanager);
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new[] {"Doctor" , "Employee"};
            foreach(string role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public static async Task SeedDoctorUser(UserManager<IdentityUser> userManager)
        {
            IdentityUser? doctorUser = await userManager.FindByNameAsync("doctor");

            if(doctorUser == null)
            {
                IdentityUser doctor = new()
                {
                    UserName = "doctor",
                    Email = "doctor@gmail.com"
                };

                IdentityResult createDoctor = await userManager.CreateAsync(doctor, "Doctor876$");
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(doctor);
                await userManager.ConfirmEmailAsync(doctor, confirmationToken);
                if(createDoctor.Succeeded)
                {
                    await userManager.AddToRoleAsync(doctor, "Doctor");
                }
            }
        }

        public static async Task SeedEmployeeUser(UserManager<IdentityUser> userManager)
        {
            IdentityUser? employeeUser = await userManager.FindByNameAsync("employee1");
            if(employeeUser == null)
            {
                IdentityUser employee1 = new()
                {
                    UserName = "employee1",
                    Email = "employee1@gmail.com"
                };

                IdentityResult createEmployee = await userManager.CreateAsync(employee1, "Employee123$");
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(employee1);
                await userManager.ConfirmEmailAsync(employee1, confirmationToken);
                if(createEmployee.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee1, "Employee");
                }
            }
        }
    }
}