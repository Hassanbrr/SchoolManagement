using DataAccess.Data;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repository
{
    public class ClassroomRepository :Repository<Classroom> , IClassroomRepository
    {
        private ApplicationDbContext _db;
        public ClassroomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Classroom obj)
        {
           _db.Classrooms.Update(obj);
        }
    }
}
