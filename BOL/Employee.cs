namespace BOL
{
    public class Employee
    {
        public int empId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string location { get; set; }
        public DateOnly joinDate { get; set; }
        public double salary { get; set; }

        public Employee()
        {

        }
        public Employee(int empId, string name, string email, string password, string location, DateOnly joinDate, double salary)
        {
            this.empId = empId;
            this.name = name;
            this.email = email;
            this.password = password;
            this.location = location;
            this.joinDate = joinDate;
            this.salary = salary;
        }
        
        public override string ToString()
        {
            return empId+name+email+location+joinDate+salary;
        }

    }
}