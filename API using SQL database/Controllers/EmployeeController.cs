using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_using_SQL_database.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace API_using_SQL_database.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage get()
        {
            DataTable table = new DataTable();
            string query = @"select EmployeeID,EmployeeName,Department,MailID,convert(varchar(10),DOJ,120) as DOJ from dbo.Employees";

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
