using Domain.Models;

namespace DataAccess.Repository.IRepository;

public interface IStudentRepository : IRepository<Student>
{
    void Update(Student obj);

}