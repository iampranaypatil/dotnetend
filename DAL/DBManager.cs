using BOL;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class DBManager
    {
        public static string coString = @"server=localhost;port=3306;user=root;password=root123;database=dotnet";

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            using (MySqlConnection con = new MySqlConnection(coString))
            {
                string query = "select * from employees";
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // empId | name         | email                    | password | location    | joinDate   | salary
                        int id = reader.GetInt32("empId");
                        string name = reader.GetString("name");
                        string email = reader.GetString("email");
                        string password= reader.GetString("password");
                        string location = reader.GetString("location");
                        DateOnly joinDate = DateOnly.FromDateTime(reader.GetDateTime("joinDate"));
                        double salary = reader.GetDouble("salary");

                        Employee employee = new (id, name, email,password, location,joinDate, salary);
                        list.Add(employee);
                        Console.WriteLine(employee);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return list;
        }

        public static bool Insert(Employee newEmp)
        {
            // empId | name         | email                    | password | location    | joinDate   | salary
            string query = "insert into employees values(" +
                "@empId,@name,@email,@password,@location,@joinDate,@salary)";
            using (MySqlConnection con = new MySqlConnection(coString)) {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@empId", newEmp.empId);
                    cmd.Parameters.AddWithValue ("@name", newEmp.name);
                    cmd.Parameters.AddWithValue("@email", newEmp.email);
                    cmd.Parameters.AddWithValue("@password", newEmp.password);
                    cmd.Parameters.AddWithValue("@location", newEmp.location);
                    cmd.Parameters.AddWithValue("@joinDate", newEmp.joinDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@salary", newEmp.salary);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

    }
}