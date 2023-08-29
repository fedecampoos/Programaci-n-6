using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using proyecto_program_6.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_program_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calsesita : ControllerBase
    {
        // GET: api/<calsesita>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<calsesita>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<calsesita>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<calsesita>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<calsesita>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("obtenerordenes")]
        public List<OrdenesHistory> obtenerordenes() {
            string connectionString = "Data Source=NB-CONSUL-117;Initial Catalog=Clase3;Integrated Security=True";

            List<OrdenesHistory> lista = new List<OrdenesHistory>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from ORDERS_HISTORY";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrdenesHistory oh = new OrdenesHistory();
                    oh.TX_NUMBER = int.Parse(reader[0].ToString());
                    oh.ORDER_DATE = DateTime.Parse(reader[1].ToString());

                    lista.Add(oh);


                }

            }

           

                return lista;
        }

    }

}
