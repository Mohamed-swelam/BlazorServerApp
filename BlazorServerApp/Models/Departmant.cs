namespace BlazorServerApp.Models;
public class Departmant
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "The Name must be between 3 and 30")]
    [MaxLength(30, ErrorMessage = "The Name must be between 3 and 30")]
    public string Name { get; set; }
    public ICollection<Student>? Students { get; set; }
}
