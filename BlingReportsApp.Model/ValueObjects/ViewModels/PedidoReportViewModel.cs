using System;
using System.Collections.Generic;
using System.Text;

namespace BlingReportsApp.Domain.ViewModels
{
    public class PedidoReportViewModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public string LinkCodeBar { get; set; }

        public List<ProdutoViewModel> Produtos { get; set; }
    }

    public class ProdutoViewModel
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string SKU { get; set; }
        public int Quantidade { get; set; }
        public string Localizacao { get; set; }
    }
}
