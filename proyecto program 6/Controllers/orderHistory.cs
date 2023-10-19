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
    public class orderHistory : ControllerBase
    {

        string connectionString = "Data Source=LAPTOP-BTR6NGVS\\SQLEXPRESS01;Initial Catalog=Prog6;Integrated Security=True";

        [HttpGet]
        [Route("obtenerordenes")]
        public List<OrdenesHistory> obtenerordenes() {

            List<OrdenesHistory> lista = new List<OrdenesHistory>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select TX_NUMBER, ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE from ORDERS_HISTORY";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                OrdenesHistory oh = new OrdenesHistory();
                oh.TX_NUMBER = int.Parse(reader[0].ToString());
                oh.ORDER_DATE = Convert.ToDateTime(reader[1].ToString());
                oh.ACTION = reader[2].ToString();
                oh.STATUS = reader[3].ToString();
                oh.SYMBOL = reader[4].ToString();
                oh.QUANTITY = int.Parse(reader[5].ToString());
                oh.PRICE = double.Parse(reader[6].ToString());

                lista.Add(oh);


            }




            connection.Close();

            return lista;
        }

        [HttpGet]
        [Route("obtenerordenesYears")]
        public List<OrdenesHistory> obtenerordenesYears(string year)
        {

            List<OrdenesHistory> lista = new List<OrdenesHistory>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select TX_NUMBER, ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE from ORDERS_HISTORY where YEAR(ORDER_DATE) = '" + year + "';";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                OrdenesHistory oh = new OrdenesHistory();
                oh.TX_NUMBER = int.Parse(reader[0].ToString());
                oh.ORDER_DATE = Convert.ToDateTime(reader[1].ToString());
                oh.ACTION = reader[2].ToString();
                oh.STATUS = reader[3].ToString();
                oh.SYMBOL = reader[4].ToString();
                oh.QUANTITY = int.Parse(reader[5].ToString());
                oh.PRICE = double.Parse(reader[6].ToString());

                lista.Add(oh);


            }




            connection.Close();

            return lista;
        }

        [HttpPost]
        [Route("CrearOrdenes")]

        public bool crearOrdenes(OrdenesHistory O) 
        {
            
            string query = "insert into orders_history ( ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE) values(getdate(),'" + O.ACTION + "','" + O.STATUS + "','" + O.SYMBOL + "'," + O.QUANTITY + "," + O.PRICE + ");";
            SqlConnection sqlConn = new SqlConnection(connectionString);

            sqlConn.Open();
            
            SqlCommand cm = new SqlCommand(query, sqlConn);

            cm.ExecuteNonQuery();

            sqlConn.Close();

            return true;
        }
      


    }

}
