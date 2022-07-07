using BlingReportsApp.Domain.Entities;
using BlingReportsApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using BlingReportsApp.Domain.ValueObjects;

namespace BlingReportsApp.Application.Services
{
    public class ConsultaSituacaoService : IConsultaSituacaoService
    {
        private const string API_KEY = "f9dcd08aa7a96717de592ca11dddd699bd5800efc612304ce15983afbc07a7563834dc93";
        public RootSituacao ConsultaSituacao(string modulo)
        {
            var client = new RestClient("https://bling.com.br");
            var request = new RestRequest($"Api/v2/situacao/{modulo}/json&apikey={API_KEY}", Method.Get);
            var response = client.GetAsync<RootSituacao>(request).Result;

            return response;
        }

        public List<SituacaoValue> GetSituacoes(string modulo)
        {
            var situacoesReturn = ConsultaSituacao(modulo);
            var situacoesValue = situacoesReturn.retorno.situacoes.Select(x => new SituacaoValue
                { Id = int.Parse(x.situacao.id), Descricao = x.situacao.nome }).ToList();

            return situacoesValue;
        }

       
    }
}
