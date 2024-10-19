namespace BlazorServerApp.Components.Pages.Departments;
public partial class Delete
{
    [Parameter]
    public int Id { get; set; }
    private bool isDisabled = true;
    [BindProperty]
    Departmant? departmant { get; set; } = new Departmant();
    [Inject] IUnitOfWork? IUnitOfWork { get; set; }
    [Inject] NavigationManager? _navigationManager { get; set; }
    protected override async void OnInitialized()
    {
        if (IUnitOfWork != null)
        {
            departmant = await IUnitOfWork.DepartmentRepsitory.Get(e=>e.Id == Id);

            if (departmant == null)
            {
                _navigationManager?.NavigateTo("/Departments/Index");
            }
        }
    }
    private async Task HandleValidSubmit()
    {
        if (IUnitOfWork is not null && _navigationManager is not null && departmant is not null)
        {

            await IUnitOfWork.DepartmentRepsitory.Delete(departmant.Id);  
            _navigationManager.NavigateTo("/Departments/Index");
        }

    }
}