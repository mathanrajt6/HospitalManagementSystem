using Microsoft.EntityFrameworkCore;

namespace HMSUserAPI.Models.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<UserDetail>? UserDetails { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().Property(ud => ud.UserDetailID).ValueGeneratedNever();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorID).ValueGeneratedNever();
            modelBuilder.Entity<Patient>().Property(p => p.PatientID).ValueGeneratedNever();

        }

    }

    
}
