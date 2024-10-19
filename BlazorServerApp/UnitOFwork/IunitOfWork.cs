namespace BlazorServerApp.UnitOFwork;
public interface IUnitOfWork
{
    Repository<Student> StudentRepository { get; }
    Repository<Departmant> DepartmentRepsitory { get; }
}
