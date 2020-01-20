using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<PlaceOfWork> PlaceOfWork { get; set; }
        public DbSet<WorkSchedule> WorkSchedule { get; set; }
        public DbSet<Appreciated> Appreciated { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
