using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_PMESP.Entities;
using Teste_PMESP.Interfaces;

namespace Teste_PMESP.Business
{
    public class ContractBusiness : IContractBusiness
    {
        public ContractEntity<T> ConvertContractsWCF<T>(ReturnEntity<T> returnCentrals)
        {
            ContractEntity<T> ReturnObjectContract = new ContractEntity<T>();

            ReturnObjectContract.Answer = returnCentrals.Answer;
            ReturnObjectContract.Description = returnCentrals.Description;
            ReturnObjectContract.Value = returnCentrals.Value;

            return ReturnObjectContract;
        }
    }
}
