namespace BlazorServerApp.Models;
public class Student
{
    [Key]
    public int Id { get; set; }
    //[Required(ErrorMessage = "Name is required")]
    //[MinLength(3,ErrorMessage ="The Name must be between 3 and 30")]
    //[MaxLength(30,ErrorMessage = "The Name must be between 3 and 30")]
    public string Name { get; set; }
    //[Required]
    //[Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
    public int Age {  get; set; }
    //[Required(ErrorMessage = "Email is required")]
    //[EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
    //[Required(ErrorMessage = "Please select a department")]
    public int? dept_Id { get; set; }
    [ForeignKey("dept_Id")]
    public Departmant? departmant { get; set; }
}
