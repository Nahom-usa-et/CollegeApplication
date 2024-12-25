using CollegeApplication.Models;
namespace CollegeApplication.Data.Repositories.onmemoryrepository
{
    public static class StudentRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
        new Student
            {
            Id = 1,
            Name = "Studentnumone",
            Email="Student@outlook.com",
            phone ="123456789"
            } ,
        new Student
        {
            Id = 2,
            Name = "Student002222",
            Email="Student2222@yahoo.com",
            phone ="7878758257"
        },
        new Student
        {
            Id = 3,
            Name = "Student0003333",
            Email="Studen33333@gmail.com",
            phone ="090609696454"
        }

        };

    }
}
