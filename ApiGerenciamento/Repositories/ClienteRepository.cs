using System.Collections.Generic;
using ApiGerenciamento.Interfaces;
using ApiGerenciamento.Models;
using MySql.Data.MySqlClient;

namespace ApiGerenciamento.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private MySqlConnection connection;
        public ClienteRepository(MySqlConnection conn)
        {
            this.connection = conn;
        }
        public Cliente Login(string cpf, string password)
        {
            Cliente c = new Cliente();
            string sql = "SELECT * FROM CLIENTES WHERE CPF = ? AND SENHA = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@cpf", MySqlDbType.String).Value = cpf;
                command.Parameters.Add("@senha", MySqlDbType.String).Value = password;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c.Id = reader.GetInt32("ID");
                        c.DataNascimento = reader.GetDateTime("DATA_NASCIMENTO");
                        c.DataRegistro = reader.GetDateTime("DATA_REGISTRO");
                        c.Nome = reader.GetString("NOME");
                        c.Email = reader.GetString("EMAIL");
                        c.Endereco = reader.GetString("ENDERECO");
                        c.Cpf = reader.GetString("CPF");
                        c.Credito = reader.GetDecimal("CREDITO");
                        c.Senha = reader.GetString("SENHA");
                    }
                }
            }
            return c;
        }
        public List<Cliente> ListarPaginado(int start, int limit)
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "SELECT * FROM CLIENTES LIMIT START, LIMIT";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@start", MySqlDbType.String).Value = start;
                command.Parameters.Add("@limit", MySqlDbType.String).Value = limit;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente c = new Cliente();
                        c.Id = reader.GetInt32("ID");
                        c.DataNascimento = reader.GetDateTime("DATA_NASCIMENTO");
                        c.DataRegistro = reader.GetDateTime("DATA_REGISTRO");
                        c.Nome = reader.GetString("NOME");
                        c.Email = reader.GetString("EMAIL");
                        c.Endereco = reader.GetString("ENDERECO");
                        c.Cpf = reader.GetString("CPF");
                        c.Credito = reader.GetDecimal("CREDITO");
                        c.Senha = reader.GetString("SENHA");
                        clientes.Add(c);
                    }
                }
            }
            return clientes;
        }
        public void Incluir(Cliente c)
        {
            string sql = @"INSERT INTO CLIENTES (DATA_REGISTRO, DATA_NASCIMENTO, NOME, EMAIL, ENDERECO, CPF, CREDITO, SENHA) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@DATA_REGISTRO", MySqlDbType.Date).Value = c.DataRegistro;
                command.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = c.DataNascimento;
                command.Parameters.Add("@NOME", MySqlDbType.String).Value = c.Nome;
                command.Parameters.Add("@EMAIL", MySqlDbType.String).Value = c.Email;
                command.Parameters.Add("@ENDERECO", MySqlDbType.String).Value = c.Endereco;
                command.Parameters.Add("@CPF", MySqlDbType.String).Value = c.Cpf;
                command.Parameters.Add("@CREDITO", MySqlDbType.Decimal).Value = c.Credito;
                command.Parameters.Add("@SENHA", MySqlDbType.String).Value = c.Senha;
                command.ExecuteNonQuery();
            }
        }
        public void Excluir(int id)
        {
            string sql = "DELETE FROM CLIENTES WHERE ID = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public Cliente BuscaPorId(int id)
        {
            Cliente c = new Cliente();
            string sql = "SELECT * FROM CLIENTES WHERE ID = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@ID", MySqlDbType.String).Value = id;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c.Id = reader.GetInt32("ID");
                        c.DataNascimento = reader.GetDateTime("DATA_NASCIMENTO");
                        c.DataRegistro = reader.GetDateTime("DATA_REGISTRO");
                        c.Nome = reader.GetString("NOME");
                        c.Email = reader.GetString("EMAIL");
                        c.Endereco = reader.GetString("ENDERECO");
                        c.Cpf = reader.GetString("CPF");
                        c.Credito = reader.GetDecimal("CREDITO");
                        c.Senha = reader.GetString("SENHA");
                    }
                }
            }
            return c;
        }
        public void Alterar(Cliente c)
        {
            string sql = @"UPDATE CLIENTES SET DATA_NASCIMENTO = ?, NOME = ?, EMAIL = ?, ENDERECO = ?, 
            CPF = ?, SENHA = ? WHERE ID = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = c.DataNascimento;
                command.Parameters.Add("@NOME", MySqlDbType.String).Value = c.Nome;
                command.Parameters.Add("@EMAIL", MySqlDbType.String).Value = c.Email;
                command.Parameters.Add("@ENDERECO", MySqlDbType.String).Value = c.Endereco;
                command.Parameters.Add("@CPF", MySqlDbType.String).Value = c.Cpf;
                command.Parameters.Add("@SENHA", MySqlDbType.String).Value = c.Senha;
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = c.Id;
                command.ExecuteNonQuery();
            }
        }
    }
}