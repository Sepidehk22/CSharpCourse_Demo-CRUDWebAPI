using System.Data;
using System.Data.SqlClient;

namespace WebApplication5.Models
{
    public class Dal
    {
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter da= new SqlDataAdapter("select * from tblCRUD",connection);

            DataTable dt= new DataTable();

            List<Employee> lstEmployees = new List<Employee>();

            da.Fill(dt);

            if(dt.Rows.Count > 0 )
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee =new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    employee.Name = dt.Rows[i]["Name"].ToString() ;
                    employee.Email = dt.Rows[i]["Email"].ToString();
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    lstEmployees.Add(employee);
                }
            }
            if (lstEmployees.Count > 0 )
            {
                response.statusCode = 200;
                response.statusMessage = "Data Found";
                response.employees = lstEmployees;
            }
            else
            {
                response.statusCode=404;
                response.statusMessage = "Data not Found";
                response.employees = null;
            }
            return response;

        }
        public Response GetEmployeeById(SqlConnection connection, int id)
        {
            Response response = new Response();

            SqlDataAdapter da = new SqlDataAdapter("select * from tblCRUD WHERE ID='"+id+"' AND IsActive=1", connection);

            DataTable dt = new DataTable();

         
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
               
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                    employee.Name = dt.Rows[0]["Name"].ToString();
                    employee.Email = dt.Rows[0]["Email"].ToString();
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    response.statusCode = 200;
                    response.statusMessage = "Data Found";
                    response.employee=employee ;
            }

       
                            
            else
            {
                response.statusCode = 404;
                response.statusMessage = "Data not Found";
                response.employee = null;
            }
            return response;

        }

        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand da = new SqlCommand("INSERT INTO tblCRUD(Name, Email, Isactive , CreatedOn) Values('"+employee.Name+"','"+employee.Email+"','"+employee.IsActive+"',GETDATE())" , connection);

            connection.Open();

            int i = da.ExecuteNonQuery();
            connection.Close();
       
            if (i> 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Employee added";
            }

            else
            {
                response.statusCode = 404;
                response.statusMessage = "No data inserted";
       
            }
            return response;

        }
        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand da = new SqlCommand("UPDATE tblCRUD SET Name='" + employee.Name + "',Email='" + employee.Email + "'WHERE ID ='" + employee.Id +"'" , connection);

            connection.Open();

            int i = da.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Employee updated";
            }

            else
            {
                response.statusCode = 404;
                response.statusMessage = "No data updated";

            }
            return response;

        }
        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();

            SqlCommand da = new SqlCommand("DELETE tblCRUD WHERE ID='" + id + "'", connection);

            connection.Open();

            int i = da.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Employee Deleted";
            }

            else
            {
                response.statusCode = 404;
                response.statusMessage = "No data Deleted";

            }
            return response;

        }


    }
}
