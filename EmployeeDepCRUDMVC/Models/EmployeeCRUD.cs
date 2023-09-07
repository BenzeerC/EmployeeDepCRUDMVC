using System.Data.SqlClient;

namespace EmployeeDepCRUDMVC.Models
{
    public class EmployeeCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public EmployeeCRUD(IConfiguration configuration) 
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            string qry = "select emp.*, dept.depname from EmployeeMVC emp inner join" +
                " DepartmentMVC dept on dept.depid = emp.depid";

            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.Salary = Convert.ToDouble(dr["salary"]);
                    emp.ImageUrl = dr["imageurl"].ToString();
                    emp.DepID = Convert.ToInt32(dr["depid"]);
                    emp.DepName = dr["depname"].ToString();
                    list.Add(emp);



                }
            }
            con.Close();
            return list;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string qry = "select emp.*, dept.depname from EmployeeMVC emp inner join " +
                "DepartmentMVC dept on dept.depid = emp.depid where emp.id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.Salary = Convert.ToDouble(dr["salary"]);
                    emp.ImageUrl = dr["imageurl"].ToString();
                    emp.DepID = Convert.ToInt32(dr["depid"]);
                    emp.DepName = dr["Dname"].ToString();
                }
            }
            con.Close();
            return emp;
        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            string qry = "insert into EmployeeMVC values(@name,@salary,@imageurl,@depid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@imageurl", emp.ImageUrl);
            cmd.Parameters.AddWithValue("@depid", emp.DepID);
            //cmd.Parameters.AddWithValue("@depname",emp.DepName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            string qry = "update EmployeeMVC set name=@name,salary=@salary,imageurl=@imageurl," +
                "depid=@depid where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@imageurl", emp.ImageUrl);
            cmd.Parameters.AddWithValue("@depid", emp.DepID);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "delete from EmployeeMVC where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }









    }
}
