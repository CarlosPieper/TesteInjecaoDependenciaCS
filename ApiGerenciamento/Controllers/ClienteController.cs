using ApiGerenciamento.Interfaces;
using ApiGerenciamento.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ApiGerenciamento.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository repositorio;
        public ClienteController(IClienteRepository repository)
        {
            this.repositorio = repository;
        }

        #region Login
        [ActionName("Login")]
        [HttpGet]
        public Cliente Login(string cpf, string senha)
        {
            Cliente c = repositorio.Login(cpf, senha);
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
                repositorio.Incluir(c);
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
                repositorio.Excluir(id);
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
                Cliente c = repositorio.BuscaPorId(id);
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
        public bool Alterar(string dados)
        {
            bool success = true;
            Cliente c = JsonConvert.DeserializeObject<Cliente>(dados);
            try
            {
                repositorio.Alterar(c);
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