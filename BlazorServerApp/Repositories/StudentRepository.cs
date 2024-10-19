
namespace BlazorServerApp.Repositories;
public class StudentRepository : Repository<Student>, IStudentRepository
{
    private readonly Applicationdbcontext context;

    public StudentRepository(Applicationdbcontext context) : base(context)
    {
        this.context = context;
    }


}
