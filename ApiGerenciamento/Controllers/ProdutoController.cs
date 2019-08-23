using System.Collections.Generic;
using ApiGerenciamento.Interfaces;
using ApiGerenciamento.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ApiGerenciamento.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository repositorio;
        public ProdutoController(IProdutoRepository repository)
        {
            this.repositorio = repository;
        }
        
        #region Cadastrar
        [ActionName("Cadastrar")]
        [HttpPost]
        public bool Cadastrar(string dados)
        {
            bool success = true;
            Produto p = JsonConvert.DeserializeObject<Produto>(dados);
            try
            {
                repositorio.Incluir(p);
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
        public Produto BuscarPorId(int id)
        {
            try
            {
                Produto p = repositorio.BuscaPorId(id);
                return p;
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
            Produto p = JsonConvert.DeserializeObject<Produto>(dados);
            try
            {
                repositorio.Alterar(p);
            }
            catch (MySqlException ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        #endregion

        #region ListarPaginado
        [ActionName("ListarPaginado")]
        [HttpGet]
        public List<Produto> ListarPaginado(int start, int limit)
        {
            List<Produto> produtos = repositorio.ListarPaginado(start, limit);
            return produtos;
        }
        #endregion
    }
}