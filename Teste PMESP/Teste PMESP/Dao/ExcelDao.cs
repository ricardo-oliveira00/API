using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_PMESP.Entities;

namespace Teste_PMESP.Dao
{
    public class ExcelDao
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5BduFm6jytX8glBNDLV6JaHojFohVnzD4CYWEzTI",
            BasePath = "https://teste-pmesp-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public string IncluirBD(List<ExcelEntity> dadosExcel)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                var data = dadosExcel;
                PushResponse response = client.Push("teste/", data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "Incluido com sucesso !!!";
        }
    }
}
