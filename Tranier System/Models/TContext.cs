using Microsoft.EntityFrameworkCore;

namespace Tranier_System.Models
{
    public class TContext:DbContext
    {
        public TContext():base() { }
        public TContext(DbContextOptions<TContext> options) : base(options) { }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Trainee> Trainee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AHMED\\MSSQLSERVER01;Initial Catalog=TrainerSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department(){Id = 1,Name = "SD",Manager="Ahmed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 2, Name = "OS", Manager = "Loai" });

            modelBuilder.Entity<Course>().HasData(new Course() { Id = 1, Name = "JS", Degree = 100, MinDegree = 60, DepartmentId = 2 });
            modelBuilder.Entity<Course>().HasData(new Course() { Id=2, Name="Mvc",Degree=100,MinDegree=60,DepartmentId=1});

            modelBuilder.Entity<Trainee>().HasData(new Trainee() {  Id = 1, Name ="Khalid",Image="1.png",Address="Menouf",Degree=3,DepartmentId=1});
            modelBuilder.Entity<Trainee>().HasData(new Trainee() {  Id = 2, Name ="Moaz",Image="2.png",Address="Cairo",Degree=4,DepartmentId=2});

            modelBuilder.Entity<Instructor>().HasData(new Instructor() { Id = 1, Name = "Islam", Image = "2.png", Salary = 6543.65, Address = "Giza", DepartmentId = 1, CourseId = 2 });
            modelBuilder.Entity<Instructor>().HasData(new Instructor() { Id = 2, Name = "Ali", Image = "1.png", Salary = 9543, Address = "Tanta", DepartmentId = 2, CourseId = 1 });

            modelBuilder.Entity<CrsResult>().HasData(new CrsResult() { Id=1,Degree=80,CourseId=2,TranieeId=1});
            modelBuilder.Entity<CrsResult>().HasData(new CrsResult() { Id=2,Degree=90,CourseId=1,TranieeId=2});

            base.OnModelCreating(modelBuilder);
        }
    }
}
