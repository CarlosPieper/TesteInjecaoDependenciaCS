using ApiGerenciamento.Models;
using ApiGerenciamento.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ApiGerenciamento.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteRepository repositorio = new ClienteRepository();
        MySqlConnection connection = Database.Connect();

        #region Login
        [ActionName("Login")]
        [HttpGet]
        public Cliente Login(string cpf, string senha)
        {
            connection.Open();
            Cliente c = repositorio.Login(cpf, senha, connection);
            connection.Close();
            return c;
        }
        #endregion

        #region Cadastrar
        [ActionName("Cadastrar")]
        [HttpPost]
        public bool Cadastrar(string dados)
        {
            bool success = true;
            Cliente c = JsonConvert.DeserializeObject<Cliente>(dados);
            try
            {
                connection.Open();
                repositorio.Incluir(c, connection);
                connection.Close();
            }
            catch (MySqlException ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        #endregion

        #region Deletar
        [ActionName("Deletar")]
        [HttpDelete]
        public bool Deletar(int id)
        {
            bool success = true;
            try
            {
                connection.Open();
                repositorio.Excluir(id, connection);
                connection.Close();
            }
            catch (MySqlException ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        #endregion

        #region BuscarPorId
        [ActionName("BuscarPorId")]
        [HttpGet]
        public Cliente BuscarPorId(int id)
        {
            try
            {
                connection.Open();
                Cliente c = repositorio.BuscaPorId(id, connection);
                connection.Close();
                return c;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        #endregion
    
        #region Alterar
        [ActionName("Alterar")]
        [HttpPost]
        public bool Alterar (string dados)
        {
            bool success = true;
            Cliente c = JsonConvert.DeserializeObject<Cliente>(dados);
            try
            {
                connection.Open();
                repositorio.Alterar(c, connection);
                connection.Close();
            }
            catch (MySqlException ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        #endregion
    }
}