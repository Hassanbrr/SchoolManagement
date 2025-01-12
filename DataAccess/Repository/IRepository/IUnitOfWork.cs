namespace DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IClassroomRepository Classroom { get; }
    IStudentRepository Student { get; }
    void Save();

}