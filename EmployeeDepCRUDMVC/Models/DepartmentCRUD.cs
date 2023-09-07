using System.Data.SqlClient;

namespace EmployeeDepCRUDMVC.Models
{
    public class DepartmentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public DepartmentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> list = new List<Department>();
            string qry = "select * from DepartmentMVC";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department d = new Department();
                    d.DepId= Convert.ToInt32(dr["depid"]);
                    d.DepName = dr["depname"].ToString();
                    
                    list.Add(d);


                }
            }
            con.Close();
            return list;
        }
        public Department GetDepartmentById(int id)
        {
            Department d = new Department();
            string qry = "select * from DepartmentMVC where depid=@depid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@depid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    d.DepId = Convert.ToInt32(dr["depid"]);
                    d.DepName = dr["depname"].ToString();
                   
                }
            }
            con.Close();
            return d;
        }
        public int AddDepartMent(Department department)
        {
            
            int result = 0;
            string qry = "insert into DepartmentMVC values(@depid,@depname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@depid",department.DepId);
            cmd.Parameters.AddWithValue("@depname", department.DepName);
            
            con.Open();

            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateDepartment(Department department)
        {
            
            int result = 0;
            string qry = "update DepartmentMVC set depname=@depname where depid=@depid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@depname", department.DepName);
            
            cmd.Parameters.AddWithValue("@depid", department.DepId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        // soft delete --> record should be present in DB , but should not visible on the form
        public int DeleteDepartment(int id)
        {
            int result = 0;
            string qry = "Delete from DepartmentMVC where depid=@depid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@depid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
