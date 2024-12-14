namespace DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IClassroomRepository Classroom { get; }
    void Save();

}