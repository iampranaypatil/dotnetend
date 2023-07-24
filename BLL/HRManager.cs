using BOL;
using DAL;

namespace BLL
{
    public class HRManager
    {
        public List<Employee> AllEmployees()
        {
            List<Employee> list;
            list = DBManager.GetAllEmployees();
            return list;
        }

        public bool AddNewEMP(Employee employee)
        {
           bool add= DBManager.Insert(employee);
            if (add)
            {
                return true;
            }
            return false;
        }
    }
}