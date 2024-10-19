namespace BlazorServerApp.Components.Pages.Departments;
public partial class Upsert
{
    [Parameter]
    public int? Id { get; set; }
    [Inject] IUnitOfWork? IUnitOfWork { get; set; }
    [Inject] NavigationManager? _navigationManager { get; set; }
    [BindProperty]
    Departmant? departmant { get; set; } = new Departmant();
    bool NotFoundError { get; set; } = false;
    protected async override Task OnInitializedAsync()
    {
        if (Id == null)
        {
            departmant = new Departmant();
        }
        else
        {
            if (IUnitOfWork != null)
            {
                departmant = await IUnitOfWork.DepartmentRepsitory.GetById(Id);

            }
            if (departmant == null)
            {
                NotFoundError = true;                    
            }
        }
    }

    private async Task HandleValidSubmit()
    {
        if (IUnitOfWork is not null && _navigationManager is not null && departmant is not null)
        {
            if (Id == null)
            {
                await IUnitOfWork.DepartmentRepsitory.Insert(departmant);
            }
            else
            {
               await IUnitOfWork.DepartmentRepsitory.Update(departmant);
            }
            _navigationManager.NavigateTo("/Departments/Index");
        }
        
    }
}
