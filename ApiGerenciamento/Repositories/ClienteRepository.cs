using ApiGerenciamento.Models;
using MySql.Data.MySqlClient;

namespace ApiGerenciamento.Repositories
{
    public class ClienteRepository
    {
        public Cliente Login(string cpf, string password, MySqlConnection conn)
        {
            Cliente c = new Cliente();
            string sql = "SELECT * FROM CLIENTES WHERE CPF = ? AND SENHA = ?";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@cpf", MySqlDbType.String).Value = cpf;
            command.Parameters.Add("@senha", MySqlDbType.String).Value = password;
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                c.id = reader.GetInt32("ID");
                c.datanascimento = reader.GetDateTime("DATA_NASCIMENTO");
                c.dataregistro = reader.GetDateTime("DATA_REGISTRO");
                c.nome = reader.GetString("NOME");
                c.email = reader.GetString("EMAIL");
                c.endereco = reader.GetString("ENDERECO");
                c.cpf = reader.GetString("CPF");
                c.credito = reader.GetDecimal("CREDITO");
                c.senha = reader.GetString("SENHA");
            }
            return c;
        }
        public void Incluir(Cliente c, MySqlConnection conn)
        {
            string sql = @"INSERT INTO CLIENTES (DATA_REGISTRO, DATA_NASCIMENTO, NOME, EMAIL, ENDERECO, CPF, CREDITO, SENHA) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@DATA_REGISTRO", MySqlDbType.Date).Value = c.dataregistro;
            command.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = c.datanascimento;
            command.Parameters.Add("@NOME", MySqlDbType.String).Value = c.nome;
            command.Parameters.Add("@EMAIL", MySqlDbType.String).Value = c.email;
            command.Parameters.Add("@ENDERECO", MySqlDbType.String).Value = c.endereco;
            command.Parameters.Add("@CPF", MySqlDbType.String).Value = c.cpf;
            command.Parameters.Add("@CREDITO", MySqlDbType.Decimal).Value = c.credito;
            command.Parameters.Add("@SENHA", MySqlDbType.String).Value = c.senha;
            command.ExecuteNonQuery();
        }
        public void Excluir (int id, MySqlConnection conn)
        {
            string sql = "DELETE FROM CLIENTES WHERE ID = ?";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.ExecuteNonQuery();
        }
        public Cliente BuscaPorId(int id, MySqlConnection conn)
        {
            Cliente c = new Cliente();
            string sql = "SELECT * FROM CLIENTES WHERE ID = ?";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@ID", MySqlDbType.String).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                c.id = reader.GetInt32("ID");
                c.datanascimento = reader.GetDateTime("DATA_NASCIMENTO");
                c.dataregistro = reader.GetDateTime("DATA_REGISTRO");
                c.nome = reader.GetString("NOME");
                c.email = reader.GetString("EMAIL");
                c.endereco = reader.GetString("ENDERECO");
                c.cpf = reader.GetString("CPF");
                c.credito = reader.GetDecimal("CREDITO");
                c.senha = reader.GetString("SENHA");
            }
            return c;
        }
        public void Alterar (Cliente c, MySqlConnection conn)
        {
            string sql = @"UPDATE CLIENTES SET DATA_NASCIMENTO = ?, NOME = ?, EMAIL = ?, ENDERECO = ?, 
            CPF = ?, SENHA = ? WHERE ID = ?";
            MySqlCommand command = new MySqlCommand (sql, conn);
            command.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = c.datanascimento;
            command.Parameters.Add("@NOME", MySqlDbType.String).Value = c.nome;
            command.Parameters.Add("@EMAIL", MySqlDbType.String).Value = c.email;
            command.Parameters.Add("@ENDERECO", MySqlDbType.String).Value = c.endereco;
            command.Parameters.Add("@CPF", MySqlDbType.String).Value = c.cpf;
            command.Parameters.Add("@SENHA", MySqlDbType.String).Value = c.senha;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = c.id;
            command.ExecuteNonQuery();
        }
    }
}