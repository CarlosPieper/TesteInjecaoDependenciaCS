using System.Collections.Generic;
using ApiGerenciamento.Models;
using MySql.Data.MySqlClient;

namespace ApiGerenciamento.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> ListarPaginado(int start, int limit);
        void Incluir(Produto p);
        void Excluir(int id);
        Produto BuscaPorId(int id);
        void Alterar(Produto p);
    }
}