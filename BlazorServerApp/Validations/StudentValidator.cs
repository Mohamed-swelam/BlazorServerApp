namespace BlazorServerApp.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(3, 30).WithMessage("The Name must be between 3 and 30 characters");

            RuleFor(x => x.Age)
                .InclusiveBetween(18, 60).WithMessage("Age must be between 18 and 60");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.dept_Id)
                .NotNull().WithMessage("Please select a department");
        }
    }
}
