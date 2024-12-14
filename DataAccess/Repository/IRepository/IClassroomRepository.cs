using Domain.Models;
 

namespace DataAccess.Repository.IRepository;

public interface IClassroomRepository : IRepository<Classroom>
{
    void Update(Classroom obj);
    void Save();

}