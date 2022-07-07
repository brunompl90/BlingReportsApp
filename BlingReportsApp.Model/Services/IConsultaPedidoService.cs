using System;
using System.Collections.Generic;
using System.Text;
using BlingReportsApp.Domain.Entities;
using BlingReportsApp.Domain.ViewModels;

namespace BlingReportsApp.Domain.Services
{
    public interface IConsultaPedidoService
    {
        RootPedido ConsultaPedido(int idSituacao, DateTime dataEmissaoInicio, DateTime dataEmissaoFinal);
        RootPedido ConsultaPedido(int codigoPedido);
        List<PedidoReportViewModel> GetPedidosReportSource(int idSituacao, DateTime dataEmissaoInicio, DateTime dataEmissaoFinal);

    }
}
