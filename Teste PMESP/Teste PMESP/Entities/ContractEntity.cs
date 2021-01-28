using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Teste_PMESP.Entities
{
    [DataContract]
    public class ContractEntity<T>
    {
        [DataMember]
        public int Answer { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Value { get; set; }
    }
}
