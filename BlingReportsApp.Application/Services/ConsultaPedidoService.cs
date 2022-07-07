using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlingReportsApp.Domain.Entities;
using BlingReportsApp.Domain.Services;
using BlingReportsApp.Domain.ViewModels;
using RestSharp;

namespace BlingReportsApp.Application.Services
{
    public class ConsultaPedidoService : IConsultaPedidoService
    {
        private const string API_KEY = "f9dcd08aa7a96717de592ca11dddd699bd5800efc612304ce15983afbc07a7563834dc93";

        private readonly IConsultaProdutoService _consultaProdutoService;
        public ConsultaPedidoService(IConsultaProdutoService consultaProdutoService)
        {
            _consultaProdutoService = consultaProdutoService;
        }
        public RootPedido ConsultaPedido(int idSituacao, DateTime dataEmissaoInicio, DateTime dataEmissaoFinal)
        {
            string filters = string.Empty;
            var client = new RestClient("https://bling.com.br");
            if (dataEmissaoInicio != DateTime.MinValue && dataEmissaoFinal != DateTime.MinValue)
            {
                filters = $"&filters=dataEmissao[{dataEmissaoInicio:dd/MM/yyyy} TO {dataEmissaoFinal: dd/MM/yyyy}]; idSituacao[{idSituacao}]";
            }

            var request = new RestRequest($"Api/v2/pedidos/json&apikey={API_KEY}{filters}", Method.Get);
            var response = client.GetAsync<RootPedido>(request).Result;

            return response;
        }

        public RootPedido ConsultaPedido(int codigoPedido)
        {
            var client = new RestClient("https://bling.com.br");
            var request = new RestRequest($"Api/v2/pedido/{codigoPedido}/json&apikey={API_KEY}", Method.Get);
            var response = client.GetAsync<RootPedido>(request).Result;

            return response;
        }

        public List<PedidoReportViewModel> GetPedidosReportSource(int idSituacao, DateTime dataEmissaoInicio, DateTime dataEmissaoFinal)
        {
            var pedidosViewModel = new List<PedidoReportViewModel>();
            
            var retornoPedidos = ConsultaPedido(idSituacao, dataEmissaoInicio, dataEmissaoFinal);

            if (retornoPedidos.Retorno.Pedidos == null)
            {
                return pedidosViewModel;
            }

            foreach (var pedido in retornoPedidos.Retorno.Pedidos)
            {
                var pedidoViewModel = new PedidoReportViewModel();
                pedidoViewModel.Codigo = pedido.Pedido.Numero;
                pedidoViewModel.LinkCodeBar = $"https://www.webarcode.com/barcode/image.php?type=C128B&xres=1&height=50&width=102&font=3&output=png&style=197&code={pedidoViewModel.Codigo}";
                pedidoViewModel.Nome = pedido.Pedido.Cliente.Nome;
                pedidoViewModel.Produtos = new List<ProdutoViewModel>();

                foreach (var produto in pedido.Pedido.Itens)
                {
                    var codigoProduto = produto.Item.Codigo;
                    var produtoResult = _consultaProdutoService.ConsultaProduto(codigoProduto);

                    if (produtoResult.Retorno.Produtos[0].Produto.Estrutura != null)
                    {
                        foreach (var complemento in produtoResult.Retorno.Produtos[0].Produto.Estrutura)
                        {
                            var produtoViewModel = new ProdutoViewModel();
                            var complementoProduto = _consultaProdutoService.ConsultaProduto(complemento.Componente.Codigo);
                            produtoViewModel.Descricao = complemento.Componente.Nome;
                            produtoViewModel.SKU = complemento.Componente.Codigo;
                            produtoViewModel.Quantidade = int.Parse(complemento.Componente.Quantidade.Substring(0, complemento.Componente.Quantidade.IndexOf('.')));
                            produtoViewModel.Localizacao = complementoProduto.Retorno.Produtos[0].Produto.Localizacao;
                            pedidoViewModel.Produtos.Add(produtoViewModel);
                        }
                    }
                    else
                    {
                        var produtoViewModel = new ProdutoViewModel();
                        produtoViewModel.Descricao = produto.Item.Descricao;
                        produtoViewModel.SKU = produto.Item.Codigo;
                        produtoViewModel.Quantidade = int.Parse(produto.Item.Quantidade.Substring(0, produto.Item.Quantidade.IndexOf('.')));
                        produtoViewModel.Localizacao = produtoResult.Retorno.Produtos[0].Produto.Localizacao;
                        pedidoViewModel.Produtos.Add(produtoViewModel);
                    }


                }

                pedidosViewModel.Add(pedidoViewModel);
            }

            return pedidosViewModel;
        }
    }
}
