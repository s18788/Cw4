using Cw4.DAL;
using Cw4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        private const string conString = "Data Source=db-mssql;Initial Catalog=s18788;Integrated Security=True";


        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {
            using (var client = new SqlConnection(conString))
            using (var com = new SqlCommand())
            {

                com.Connection = client;
                com.CommandText = "select * from Students";

                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();

                    return Ok(st);
                }


            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent_02(string indexNumber)
        {
            using (var client = new SqlConnection(conString))
            using (var com = new SqlCommand())
            {

                com.Connection = client;
                com.CommandText = "select * from Students where indexNumber=@id";
                com.Parameters.AddWithValue("id", indexNumber);

                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();

                    return Ok(st);
                }


            }
            return NotFound();
        }



    }
}