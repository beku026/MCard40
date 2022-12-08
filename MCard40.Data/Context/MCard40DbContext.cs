using MCard40.Data.Configurations;
using MCard40.Model.Entity;
using MCard40.Model.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MCard40.Data.Context
{
    public class MCard40DbContext : DbContext
    {
        public MCard40DbContext(DbContextOptions<MCard40DbContext> options) : base(options)
        {

        } 

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<CardPage> CardPages { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardPageConfig());
            modelBuilder.ApplyConfiguration(new DoctorConfig());
            modelBuilder.ApplyConfiguration(new PatientConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new WorkDayConfig());
            modelBuilder.ApplyConfiguration(new WeekConfig());
        }
    }
}
