namespace BlazorServerApp.UnitOFwork;
public class UnitofWork : IUnitOfWork
{
    private readonly Applicationdbcontext applicationdbcontext;

    public Repository<Student> StudentRepository {  get; set; }

    public Repository<Departmant> DepartmentRepsitory {  get; set; }
    public UnitofWork(Applicationdbcontext applicationdbcontext)
    {
        this.applicationdbcontext = applicationdbcontext;
        StudentRepository = new Repository<Student>(applicationdbcontext);
        DepartmentRepsitory = new DepartmentRepsitory(applicationdbcontext);
    }
}
