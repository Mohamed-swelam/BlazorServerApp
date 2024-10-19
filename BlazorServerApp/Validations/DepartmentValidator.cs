namespace BlazorServerApp.Validations
{
    public class DepartmentValidator : AbstractValidator<Departmant>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required")
           .Length(3, 30).WithMessage("The Name must be between 3 and 30 characters");
        }
    }
}
