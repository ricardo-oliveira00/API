using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_PMESP.Entities;

namespace Teste_PMESP.Interfaces
{
    public interface IExcelBusiness
    {
        public string ValidaDadosRecebidos(List<ExcelEntity> DadosExcel);
        public string ValidaCampos(ExcelEntity DadosExcel, int Linha);
        public string ValidaData(DateTime Data, int Linha);
        public string ValidaDescricao(String Descricao, int Linha);
        public string ValidaQuantidade(int Quantidade, int Linha);
        public string ValidaValor(decimal Valor, int Linha);


    }
}
