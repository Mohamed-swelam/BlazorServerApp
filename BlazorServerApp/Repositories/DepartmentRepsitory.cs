namespace BlazorServerApp.Repositories
{
    public class DepartmentRepsitory : Repository<Departmant>, IDepartmentRepository
    {
        private readonly Applicationdbcontext context;

        public DepartmentRepsitory(Applicationdbcontext context) : base(context)
        {
            this.context = context;
        }
    }
}