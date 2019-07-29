using System;

namespace ApiGerenciamento.Models{
    public class Cliente
    {
        public int id { get; set; }
        public DateTime datanascimento { get; set; }
        public DateTime dataregistro { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string cpf { get; set; }
        public decimal credito { get; set; }
        public string senha { get; set; }
    }
}