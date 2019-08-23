using System.Collections.Generic;
using ApiGerenciamento.Interfaces;
using ApiGerenciamento.Models;
using MySql.Data.MySqlClient;

namespace ApiGerenciamento.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private MySqlConnection connection;
        public ProdutoRepository(MySqlConnection conn)
        {
            this.connection = conn;
        }
        public void Incluir(Produto p)
        {
            string sql = @"INSERT INTO PRODUTOS (DESCRICAO, PRECO, DATA_ESTOQUE, DATA_VALIDADE, CODIGO_BARRAS, TIPO) 
                VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@descricao", MySqlDbType.String).Value = p.Descricao;
                command.Parameters.Add("@preco", MySqlDbType.Decimal).Value = p.Preco;
                command.Parameters.Add("@data_estoque", MySqlDbType.Date).Value = p.DataEstoque;
                command.Parameters.Add("@data_validade", MySqlDbType.Date).Value = p.DataValidade;
                command.Parameters.Add("@codigo_barras", MySqlDbType.String).Value = p.CodigoBarras;
                command.Parameters.Add("@tipo", MySqlDbType.String).Value = p.Tipo;
                command.ExecuteNonQuery();
            }
        }
        public void Excluir(int id)
        {
            string sql = "DELETE FROM PRODUTOS WHERE ID = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public Produto BuscaPorId(int id)
        {
            Produto p = new Produto();
            string sql = "SELECT * FROM PRODUTOS WHERE ID = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@ID", MySqlDbType.String).Value = id;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p.Id = reader.GetInt32("ID");
                        p.Descricao = reader.GetString("DESCRICAO");
                        p.Preco = reader.GetDecimal("PRECO");
                        p.DataEstoque = reader.GetDateTime("DATA_ESTOQUE");
                        p.DataValidade = reader.GetDateTime("DATA_VALIDADE");
                        p.CodigoBarras = reader.GetString("CODIGO_BARRAS");
                        p.Tipo = reader.GetString("TIPO");
                    }
                }
            }
            return p;
        }
        public void Alterar(Produto p)
        {
            string sql = @"UPDATE PRODUTOS SET DESCRICAO = ?, PRECO = ?, DATA_ESTOQUE = ?, DATA_VALIDADE = ?, 
            CODIGO_BARRAS = ?, TIPO = ? WHERE ID = ?";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@descricao", MySqlDbType.String).Value = p.Descricao;
                command.Parameters.Add("@preco", MySqlDbType.Decimal).Value = p.Preco;
                command.Parameters.Add("@data_estoque", MySqlDbType.Date).Value = p.DataEstoque;
                command.Parameters.Add("@data_validade", MySqlDbType.Date).Value = p.DataValidade;
                command.Parameters.Add("@codigo_barras", MySqlDbType.String).Value = p.CodigoBarras;
                command.Parameters.Add("@tipo", MySqlDbType.String).Value = p.Tipo;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = p.Id;
                command.ExecuteNonQuery();
            }
        }
        public List<Produto> ListarPaginado(int start, int limit)
        {
            List<Produto> produtos = new List<Produto>();
            string sql = "SELECT * FROM PRODUTOS LIMIT @limit";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto p = new Produto();
                        p.Id = reader.GetInt32("ID");
                        p.Descricao = reader.GetString("DESCRICAO");
                        p.Preco = reader.GetDecimal("PRECO");
                        p.DataEstoque = reader.GetDateTime("DATA_ESTOQUE");
                        p.DataValidade = reader.GetDateTime("DATA_VALIDADE");
                        p.CodigoBarras = reader.GetString("CODIGO_BARRAS");
                        p.Tipo = reader.GetString("TIPO");
                        produtos.Add(p);
                    }
                }
            }
            return produtos;
        }
    }
}