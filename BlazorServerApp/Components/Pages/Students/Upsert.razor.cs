namespace BlazorServerApp;
public partial class Upsert
{
    [Parameter]
    public int? Id { get; set; }
    [Inject] IUnitOfWork? IUnitOfWork { get; set; }
    [Inject] NavigationManager? _navigationManager { get; set; }
    [BindProperty]
    Student? Student { get; set; } = new Student();
    List<Departmant> departments = new List<Departmant>();
    bool NotFoundError { get; set; } = false;
    protected async override Task OnInitializedAsync()
    {
        departments = await GetDepartmentAsync();
        if (Id == null)
        {
            Student = new Student();
        }
        else
        {
            if(IUnitOfWork != null)
            {
                 Student = await IUnitOfWork.StudentRepository.GetById(Id);
            }

            if (Student == null)
            {
                NotFoundError = true;                    
            }
        }
    }

    private async Task<List<Departmant>> GetDepartmentAsync()
    {
        if (IUnitOfWork is not null)
            return await IUnitOfWork.DepartmentRepsitory.GetAll();
        else
            return new();
    }

    private async Task HandleValidSubmit()
    {
        if (IUnitOfWork is not null && _navigationManager is not null && Student is not null)
        {
            if (Id == null)
            {
                await IUnitOfWork.StudentRepository.Insert(Student);
            }
            else
            {
                await IUnitOfWork.StudentRepository.Update(Student);
            }
            _navigationManager.NavigateTo("/Students/Index");
        }
        
    }
}
