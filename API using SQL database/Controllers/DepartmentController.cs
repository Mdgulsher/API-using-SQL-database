using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_using_SQL_database.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace API_using_SQL_database.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage get()
        {
            DataTable table = new DataTable();
            string query = @" Select DepartmentID,DepartmentName from dbo.Departments ";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))

            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
