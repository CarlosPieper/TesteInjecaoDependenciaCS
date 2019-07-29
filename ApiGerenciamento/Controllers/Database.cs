using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGerenciamento.Controllers
{
    public class Database
    {
        public static MySqlConnection Connect()
        {
            string connection = "server=localhost;port=3306;user=root;database=loja;password=;";
            MySqlConnection conn = new MySqlConnection(connection);
            return conn;
        }
    }
}