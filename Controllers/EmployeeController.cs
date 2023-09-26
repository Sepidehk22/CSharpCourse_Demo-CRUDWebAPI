using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDConnection").ToString());
            Response response = new Response();

            Dal dal = new Dal();

            response = dal.GetAllEmployees(connection);
            
            return response;

        }


        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public Response GetEmployeeById(int id)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDConnection").ToString());
            Response response = new Response();

            Dal dal = new Dal();

            response = dal.GetEmployeeById(connection, id);

            return response;

        }

        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee employee)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDConnection").ToString());
            Response response = new Response();

            Dal dal = new Dal();

            response = dal.AddEmployee(connection, employee);

            return response;

        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDConnection").ToString());
            Response response = new Response();

            Dal dal = new Dal();

            response = dal.UpdateEmployee(connection, employee);

            return response;

        }


        [HttpDelete]
        [Route("DeleteEmployee")]
        public Response DeleteEmployee(int id)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDConnection").ToString());
            Response response = new Response();

            Dal dal = new Dal();

            response = dal.DeleteEmployee(connection, id);

            return response;

        }


    }
}
