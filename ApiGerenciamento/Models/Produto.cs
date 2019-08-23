using System;

namespace ApiGerenciamento.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataEstoque { get; set; }
        public DateTime DataValidade { get; set; }
        public string CodigoBarras { get; set; }
        public string Tipo { get; set; }
    }
}