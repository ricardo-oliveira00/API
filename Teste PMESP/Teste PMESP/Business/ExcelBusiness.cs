using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_PMESP.Dao;
using Teste_PMESP.Entities;
using Teste_PMESP.Interfaces;

namespace Teste_PMESP.Business
{
    public class ExcelBusiness : IExcelBusiness
    {
        string Erro = "Há um erro nas seguintes linhas: \r";
        bool IncluirBD = true;
        public string ValidaDadosRecebidos(List<ExcelEntity> DadosExcel)
        {

            int i = 1;
            foreach (var dados in DadosExcel)
            {
                Erro += ValidaCampos(dados, i);
                Erro += ValidaData(dados.DataEntrega, i);
                Erro += ValidaDescricao(dados.NomeProduto, i);
                Erro += ValidaQuantidade(dados.Quantidade, i);
                Erro += ValidaValor(dados.ValorUnitario, i);

                i++;
            }

            if (IncluirBD)
            {
                return  Erro = new ExcelDao().IncluirBD(DadosExcel);
            }

            return Erro;
        }

        public string ValidaCampos(ExcelEntity DadosExcel, int Linha)
        {
            Erro = string.Empty;
            if (DadosExcel.DataEntrega.ToString() == null && DadosExcel.DataEntrega.ToString() == string.Empty)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Data Entrega - Erro: Campo em branco \r";
                IncluirBD = false;
            }
            else if (DadosExcel.NomeProduto.ToString() == null && DadosExcel.NomeProduto.ToString() == string.Empty)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Nome Produto - Erro: Campo em branco \r";
                IncluirBD = false;
            }
            else if (DadosExcel.Quantidade.ToString() == null && DadosExcel.Quantidade.ToString() == string.Empty)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Quantidade - Erro: Campo em branco \r";
                IncluirBD = false;
            }
            else if (DadosExcel.ValorUnitario.ToString() == null && DadosExcel.ValorUnitario.ToString() == string.Empty)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Valor Unitario - Erro: Campo em branco \r";
                IncluirBD = false;
            }
            return Erro;
        }

        public string ValidaData(DateTime Data, int Linha)
        {
            Erro = string.Empty;

            if (Data <= DateTime.Now)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Data Entrega - Erro: Data não pode ser menor ou igual o dia atual \r";
                IncluirBD = false;
            }

            return Erro;
        }

        public string ValidaDescricao(string Descricao, int Linha)
        {
            Erro = string.Empty;

            if (Descricao.Length > 50)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Nome Produto - Erro: Descrição deve ter no maximo 50 Caracteres \r";
                IncluirBD = false;
            }

            return Erro;
        }

        public string ValidaQuantidade(int Quantidade, int Linha)
        {
            Erro = string.Empty;

            if (Quantidade <= 0)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Quantidade - Erro: Quantidade deve ser maior que zero \r";
                IncluirBD = false;
            }

            return Erro;
        }

        public string ValidaValor(decimal Valor, int Linha)
        {
            Erro = string.Empty;

            if (Valor <= 0)
            {
                Erro += "Linha: " + Linha.ToString() + " - Coluna Valor - Erro: Valor deve ser maior que zero \r";
                IncluirBD = false;
            }

            return Erro;
        }
    }
}
