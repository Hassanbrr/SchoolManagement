using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Domain.Models;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    { 
        private ApplicationDbContext _db;
        public IClassroomRepository Classroom { get; private set; }
        public IStudentRepository Student { get; private set; }
        public UnitOfWork(ApplicationDbContext db)  
        {
            _db = db;
            Classroom = new ClassroomRepository(_db);
            Student = new StudentRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
