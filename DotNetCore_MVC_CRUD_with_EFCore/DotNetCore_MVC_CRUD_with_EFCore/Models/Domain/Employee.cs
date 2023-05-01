namespace DotNetCore_MVC_CRUD_with_EFCore.Models.Domain
{
    public class Employee
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirthd { get; set; }
        public string Department { get; set; }
    }
}
