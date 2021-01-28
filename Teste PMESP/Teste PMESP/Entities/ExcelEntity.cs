using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_PMESP.Entities
{
    public class ExcelEntity
    {
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
