using BlingReportsApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlingReportsApp.Application.Filters;
using BlingReportsApp.Domain.Services;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using BlingReportsApp.Domain.ViewModels;

namespace BlingReportsApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsultaSituacaoService _consultaSituacaoService;
        private readonly IConsultaPedidoService _consultaPedidoService;
        //private static List<PedidoReportViewModel> _pedidoReportViewModels;
        public HomeController(IConsultaSituacaoService consultaSituacaoService,
                              IConsultaPedidoService consultaPedidoService,
                              ILogger<HomeController> logger)
        {
            _logger = logger;
            _consultaSituacaoService = consultaSituacaoService;
            _consultaPedidoService = consultaPedidoService;
        }

        public IActionResult Index(List<PedidoReportViewModel> pedidosViewModel)
        {
            ViewData["IdSituacao"] = 0;
            ViewData["DataInicio"] = DateTime.Now;
            ViewData["DataFim"] = DateTime.Now;
            return View(pedidosViewModel);
        }
        [HttpGet]
        public object GetSituacoes(DataSourceLoadOptions loadOptions)
        {
            var situacoes = _consultaSituacaoService.GetSituacoes("Vendas");
            return DataSourceLoader.Load(situacoes, loadOptions);
        }


        public IActionResult GetPedidosViewModel(ConsultaPedidoFilter filtroPedido)
        {
            var pedidoReportViewModels = filtroPedido.IdSituacao == 0 ? new List<PedidoReportViewModel>() : _consultaPedidoService.GetPedidosReportSource(filtroPedido.IdSituacao, filtroPedido.DataInicio, filtroPedido.DataFim);
            ViewData["IdSituacao"] = filtroPedido.IdSituacao;
            ViewData["DataInicio"] = filtroPedido.DataInicio;
            ViewData["DataFim"] = filtroPedido.DataFim;

            return View("Index", pedidoReportViewModels);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
