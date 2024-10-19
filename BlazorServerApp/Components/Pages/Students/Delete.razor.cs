namespace BlazorServerApp;
public partial class Delete
{
    [Parameter]
    public int Id { get; set; }
    private bool isDisabled = true;
    [BindProperty]
    Student? Student { get; set; } = new Student(); 
    [Inject] IUnitOfWork? IUnitOfWork { get; set; }
    [Inject] NavigationManager? _navigationManager { get; set; }
    protected override async void OnInitialized()
    {
        if (IUnitOfWork != null)
        {
            Student = await IUnitOfWork.StudentRepository.Get(e=>e.Id == Id,IncludeProperites:"departmant");

            if (Student == null)
            {
                _navigationManager?.NavigateTo("/Students/Index");
            }
        }
    }
    private async Task HandleValidSubmit()
    {
        if (IUnitOfWork is not null && _navigationManager is not null && Student is not null)
        {
            await IUnitOfWork.StudentRepository.Delete(Student.Id);
            _navigationManager.NavigateTo("/Students/Index");
        }

    }
}