using ITI_Training_Hospital_System.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITI_Training_Hospital_System.Models.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var UserId = Guid.NewGuid().ToString();
            //var AdminId= Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(


                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp =Guid.NewGuid().ToString(),

                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),

                });

            base.OnModelCreating(builder);

        }

    }
}
