namespace BlazorServerApp;
public partial class Index
{
    public Student student = new Student();
    List<Student>? students = new List<Student>();
    [Inject] IUnitOfWork? IUnitOfWork { get; set; }
    Random random = new Random();
    protected async override Task OnInitializedAsync()
    {

        students = await GetStudentsAsync();

        await base.OnInitializedAsync();
    }

    private async Task<List<Student>?> GetStudentsAsync()
    {
        if (IUnitOfWork is not null)
            return await IUnitOfWork.StudentRepository.GetAll(IncludeProperites: "departmant");
        else
            return new();
    }
}