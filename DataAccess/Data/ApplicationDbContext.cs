using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;
using Domain.Models;


namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Manger> Mangers { get; set; }
        public DbSet<Deputy> Deputies { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBluilder)
        {
            //modelBluilder.Entity<School>().HasData(
            //    new School { Id = 1,Name = "Shahid Beheshti"} 
            //);
            //modelBluilder.Entity<Classroom>().HasData(
            //    new Classroom { Id = 1,ClassName = "Math",SchoolId = 1},
            //    new Classroom { Id = 2,ClassName = "Math" ,SchoolId = 1}
            //);

            modelBluilder.Entity<School>()
                .HasMany(x => x.Classrooms)
                .WithOne(y => y.School);


            modelBluilder.Entity<School>()
              .HasOne(x => x.Manger)
              .WithOne(y => y.School).HasForeignKey<Manger>(c => c.SchoolId); ;


            modelBluilder.Entity<School>()
             .HasOne(x => x.Deputy)
             .WithOne(y => y.School).HasForeignKey<Deputy>(c => c.SchoolId);


            modelBluilder.Entity<Student>()
                .HasMany(x => x.Classrooms)
                .WithMany(y => y.Students)
                .UsingEntity(j => j.ToTable("ClassroomStudent"));


            modelBluilder.Entity<Teacher>()
              .HasMany(x => x.Classrooms)
              .WithMany(y => y.Teachers)
              .UsingEntity(j => j.ToTable("ClassroomTeacher"));
        }
    }
}


