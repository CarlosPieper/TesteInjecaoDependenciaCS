using System.Collections.Generic;
using ApiGerenciamento.Models;
using MySql.Data.MySqlClient;

namespace ApiGerenciamento.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Login(string cpf, string password);
        List<Cliente> ListarPaginado(int start, int limit);
        void Incluir(Cliente c);
        void Excluir(int id);
        Cliente BuscaPorId(int id);
        void Alterar(Cliente c);
    }
}