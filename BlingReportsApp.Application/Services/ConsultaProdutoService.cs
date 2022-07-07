using BlingReportsApp.Domain.Entities;
using BlingReportsApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RestSharp;

namespace BlingReportsApp.Application.Services
{
    public class ConsultaProdutoService : IConsultaProdutoService
    {
        private const string API_KEY = "f9dcd08aa7a96717de592ca11dddd699bd5800efc612304ce15983afbc07a7563834dc93";
        public RootProduto ConsultaProduto(string codigo)
        {
            Thread.Sleep(1000);
            var client = new RestClient("https://bling.com.br");
            var request = new RestRequest($"Api/v2/produto/{codigo}/json&apikey={API_KEY}", Method.Get);
            var response = client.GetAsync<RootProduto>(request).Result;

            return response;
        }
    }
}
