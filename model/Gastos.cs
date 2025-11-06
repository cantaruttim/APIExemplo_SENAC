using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exemplo.model
{
    public class Gastos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}