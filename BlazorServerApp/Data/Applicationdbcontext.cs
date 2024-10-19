namespace BlazorServerApp.Data;
public class Applicationdbcontext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Departmant> Departmants { get; set; }

    public Applicationdbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property(e => e.dept_Id).IsRequired(false);
        modelBuilder.Entity<Departmant>()
           .HasMany(d => d.Students)
           .WithOne(s => s.departmant)
           .HasForeignKey(s => s.dept_Id)
           .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Student>()
           .HasOne(s => s.departmant)
           .WithMany(d => d.Students)
           .HasForeignKey(s => s.dept_Id)
           .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Departmant>().HasData(
           new Departmant { Id = 1, Name = "Computer Science" },
           new Departmant { Id = 2, Name = "Mathematics" },
           new Departmant { Id = 3, Name = "Physics" }
       );


        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "Mohamed swelam", Age = 20, Email = "mohamed@example.com", dept_Id = 1 },
            new Student { Id = 2, Name = "Mohamed alaa", Age = 22, Email = "alaa@example.com", dept_Id = 2 },
            new Student { Id = 3, Name = "Ahmed bahaa", Age = 23, Email = "bahaa@example.com", dept_Id = 3 }
        );

        base.OnModelCreating(modelBuilder);
    }
}
