using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_PMESP.Business;
using Teste_PMESP.Entities;

namespace Teste_PMESP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcelController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ExcelController> _logger;

        public ExcelController(ILogger<ExcelController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<ContractEntity<String>> InsereDadosExcel([FromBody] List<ExcelEntity> DadosExcel)
        {
            ContractEntity<String> ObjSeralize = new ContractEntity<String>();

            try
            {
                string ErroTratado = new ExcelBusiness().ValidaDadosRecebidos(DadosExcel);

                if(ErroTratado == "Incluido com sucesso !!!")
                {
                    ObjSeralize = new ContractBusiness().ConvertContractsWCF(new ReturnEntity<String>()
                    {
                        Answer = 200,
                        Description = "ok",
                        Value = ErroTratado
                    });
                }
                else
                {
                    ObjSeralize = new ContractBusiness().ConvertContractsWCF(new ReturnEntity<String>()
                    {
                        Answer = 400,
                        Description = "Invalido",
                        Value = ErroTratado
                    });
                }
            }
            catch (Exception ex)
            {

                ObjSeralize = new ContractBusiness().ConvertContractsWCF(new ReturnEntity<String>()
                {
                    Answer = 400,
                    Description = "Invalido: " + ex.Message,
                    Value = null
                });
            }

            return ObjSeralize;
        }
    }
}
