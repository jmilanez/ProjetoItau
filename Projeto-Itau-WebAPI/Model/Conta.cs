using System;

namespace Projeto_Itau_WebAPI.Model
{
    public class Conta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Status { get; set; }
        public int Tipo { get; set; }
    }
}