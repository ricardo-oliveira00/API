using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_PMESP.Entities
{
    public class ReturnEntity<T>
    {
        public int Answer { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
