namespace BlazorServerApp.Components.Pages.Departments;
public partial class Index
{
    public Departmant departmant = new Departmant();
    List<Departmant>? departmants = new List<Departmant>();
    [Inject] IUnitOfWork? IUnitOfWork { get; set; }
    Random random = new Random();
    protected async override Task OnInitializedAsync()
    {
        departmants = await GetDepartmentsAsync();

        await base.OnInitializedAsync();
    }

    private async Task<List<Departmant>?> GetDepartmentsAsync()
    {
        if (IUnitOfWork is not null)
            return await IUnitOfWork.DepartmentRepsitory.GetAll(IncludeProperites: "Students");
        else
            return new();
    }
}