using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using BlingReportsApp.Application.Extensions;
using BlingReportsApp.Domain.Services;
using BlingReportsApp.Domain.ViewModels;

namespace BlingReportsApp.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var services = new ServiceCollection();
            services.RegisterServices();

            var serviceProvider = services.BuildServiceProvider();
            // TestarChamadaSituacao(serviceProvider);
            // TestarChamadaPedido(serviceProvider);
              TestarChamadaProduto(serviceProvider);

            //TestarChamadaPedido(serviceProvider, 7298);
        }

        private static void TestarChamadaSituacao(ServiceProvider serviceProvider)
        {
            var consultaSituacaoService = serviceProvider.GetService<IConsultaSituacaoService>();
            var retornoSituacao = consultaSituacaoService.ConsultaSituacao("Vendas");
        }

        private static void TestarChamadaPedido(ServiceProvider serviceProvider)
        {
            var consultaPedidoService = serviceProvider.GetService<IConsultaPedidoService>();
            var retornoPedidos = consultaPedidoService.ConsultaPedido(15, new DateTime(2022, 2, 1), DateTime.Now);
        }

        private static void TestarChamadaPedido(ServiceProvider serviceProvider, int codigoPedido)
        {
            var consultaPedidoService = serviceProvider.GetService<IConsultaPedidoService>();
            var retornoPedidos = consultaPedidoService.ConsultaPedido(codigoPedido);
        }


        private static void TestarChamadaProduto(ServiceProvider serviceProvider)
        {
            var pedidosViewModel = new List<PedidoReportViewModel>();

            var consultaPedidoService = serviceProvider.GetService<IConsultaPedidoService>();
            var consultaProdutoService = serviceProvider.GetService<IConsultaProdutoService>();
            var retornoPedidos = consultaPedidoService.ConsultaPedido(7298);

            foreach (var pedido in retornoPedidos.Retorno.Pedidos)
            {
                var pedidoViewModel = new PedidoReportViewModel();
                pedidoViewModel.Codigo = pedido.Pedido.Numero;
                pedidoViewModel.LinkCodeBar = $"https://www.webarcode.com/barcode/image.php?type=C128B&xres=1&height=50&width=102&font=3&output=png&style=197&code={pedidoViewModel.Codigo}";

                pedidoViewModel.Produtos = new List<ProdutoViewModel>();

                foreach (var produto in pedido.Pedido.Itens)
                {
                    var codigoProduto = produto.Item.Codigo;
                    var produtoResult = consultaProdutoService.ConsultaProduto(codigoProduto);

                    if (produtoResult.Retorno.Produtos[0].Produto.Estrutura != null)
                    {
                        foreach (var complemento in produtoResult.Retorno.Produtos[0].Produto.Estrutura)
                        {
                            var produtoViewModel = new ProdutoViewModel();
                            produtoViewModel.Descricao = complemento.Componente.Nome;
                            produtoViewModel.SKU = complemento.Componente.Codigo;
                            produtoViewModel.Quantidade = int.Parse(complemento.Componente.Quantidade);
                            pedidoViewModel.Produtos.Add(produtoViewModel);
                        }
                    }
                    else
                    {
                        var produtoViewModel = new ProdutoViewModel();
                        produtoViewModel.Descricao = produto.Item.Descricao;
                        produtoViewModel.SKU = produto.Item.Codigo;
                        produtoViewModel.Quantidade = int.Parse(produto.Item.Quantidade);
                        pedidoViewModel.Produtos.Add(produtoViewModel);
                    }

                   
                }

                pedidosViewModel.Add(pedidoViewModel);
            }
        }
    }
}
