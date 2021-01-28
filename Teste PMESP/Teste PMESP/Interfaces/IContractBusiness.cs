using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_PMESP.Entities;

namespace Teste_PMESP.Interfaces
{
    public interface IContractBusiness
    {
        public ContractEntity<T> ConvertContractsWCF<T>(ReturnEntity<T> returnCentrals);
      
    }
}
