
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlingReportsApp.Domain.Entities
{
   

    public partial class RootPedido
    {
        [JsonProperty("retorno")]
        public RetornoPedido Retorno { get; set; }
    }

    public partial class RetornoPedido
    {
        [JsonProperty("pedidos")]
        public PedidoElement[] Pedidos { get; set; }
    }

    public partial class PedidoElement
    {
        [JsonProperty("pedido")]
        public PedidoPedido Pedido { get; set; }
    }

    public partial class PedidoPedido
    {
        [JsonProperty("desconto")]
        public string Desconto { get; set; }

        [JsonProperty("observacoes")]
        public string Observacoes { get; set; }

        [JsonProperty("observacaointerna")]
        public string Observacaointerna { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("numeroOrdemCompra")]
        public string NumeroOrdemCompra { get; set; }

        [JsonProperty("vendedor")]
        public string Vendedor { get; set; }

        [JsonProperty("valorfrete")]
        public string Valorfrete { get; set; }

        [JsonProperty("outrasdespesas")]
        public string Outrasdespesas { get; set; }

        [JsonProperty("totalprodutos")]
        public string Totalprodutos { get; set; }

        [JsonProperty("totalvenda")]
        public string Totalvenda { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("dataSaida")]
        public string DataSaida { get; set; }

        [JsonProperty("loja")]
        public string Loja { get; set; }

        [JsonProperty("numeroPedidoLoja")]
        public string NumeroPedidoLoja { get; set; }

        [JsonProperty("tipoIntegracao")]
        public string TipoIntegracao { get; set; }

        [JsonProperty("cliente")]
        public Cliente Cliente { get; set; }

        [JsonProperty("nota")]
        public Nota Nota { get; set; }

        [JsonProperty("transporte")]
        public Transporte Transporte { get; set; }

        [JsonProperty("intermediador")]
        public Intermediador Intermediador { get; set; }

        [JsonProperty("itens")]
        public Iten[] Itens { get; set; }

        [JsonProperty("parcelas")]
        public ParcelaElement[] Parcelas { get; set; }

        [JsonProperty("codigosRastreamento")]
        public CodigosRastreamento CodigosRastreamento { get; set; }
    }

    public partial class Cliente
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("ie")]
        public string Ie { get; set; }

        [JsonProperty("rg")]
        public string Rg { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("fone")]
        public string Fone { get; set; }
    }

    public partial class CodigosRastreamento
    {
        [JsonProperty("codigoRastreamento")]
        public string CodigoRastreamento { get; set; }
    }

    public partial class Intermediador
    {
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("nomeUsuario")]
        public string NomeUsuario { get; set; }
    }

    public partial class Iten
    {
        [JsonProperty("item")]
        public Item Item { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("quantidade")]
        public string Quantidade { get; set; }

        [JsonProperty("valorunidade")]
        public string Valorunidade { get; set; }

        [JsonProperty("precocusto")]
        public string Precocusto { get; set; }

        [JsonProperty("descontoItem")]
        public string DescontoItem { get; set; }

        [JsonProperty("un")]
        public string Un { get; set; }

        [JsonProperty("pesoBruto")]
        public string PesoBruto { get; set; }

        [JsonProperty("largura")]
        public string Largura { get; set; }

        [JsonProperty("altura")]
        public string Altura { get; set; }

        [JsonProperty("profundidade")]
        public string Profundidade { get; set; }

        [JsonProperty("descricaoDetalhada")]
        public string DescricaoDetalhada { get; set; }

        [JsonProperty("unidadeMedida")]
        public string UnidadeMedida { get; set; }

        [JsonProperty("gtin")]
        public string Gtin { get; set; }
    }

    public partial class Nota
    {
        [JsonProperty("serie")]
        public string Serie { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("dataEmissao")]
        public string DataEmissao { get; set; }

        [JsonProperty("situacao")]
        
        public string Situacao { get; set; }

        [JsonProperty("valorNota")]
        public string ValorNota { get; set; }

        [JsonProperty("chaveAcesso")]
        public string ChaveAcesso { get; set; }
    }

    public partial class ParcelaElement
    {
        [JsonProperty("parcela")]
        public ParcelaParcela Parcela { get; set; }
    }

    public partial class ParcelaParcela
    {
        [JsonProperty("idLancamento")]
        public string IdLancamento { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("dataVencimento")]
        public string DataVencimento { get; set; }

        [JsonProperty("obs")]
        public string Obs { get; set; }

        [JsonProperty("destino")]
        public string Destino { get; set; }

        [JsonProperty("forma_pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
    }

    public partial class FormaPagamento
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("codigoFiscal")]
      
        public string CodigoFiscal { get; set; }
    }

    public partial class Transporte
    {
        [JsonProperty("transportadora")]
        public string Transportadora { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("tipo_frete")]
        public string TipoFrete { get; set; }

        [JsonProperty("qtde_volumes")]
        public string QtdeVolumes { get; set; }

        [JsonProperty("enderecoEntrega")]
        public EnderecoEntrega EnderecoEntrega { get; set; }

        [JsonProperty("volumes")]
        public VolumeElement[] Volumes { get; set; }

        [JsonProperty("servico_correios")]
        public string ServicoCorreios { get; set; }
    }

    public partial class EnderecoEntrega
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }
    }

    public partial class VolumeElement
    {
        [JsonProperty("volume")]
        public VolumeVolume Volume { get; set; }
    }

    public partial class VolumeVolume
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("idServico")]
        public string IdServico { get; set; }

        [JsonProperty("idOrigem")]
        public string IdOrigem { get; set; }

        [JsonProperty("servico")]
        public string Servico { get; set; }

        [JsonProperty("codigoServico")]
        public string CodigoServico { get; set; }

        [JsonProperty("codigoRastreamento")]
        public string CodigoRastreamento { get; set; }

        [JsonProperty("valorFretePrevisto")]
        public string ValorFretePrevisto { get; set; }

        [JsonProperty("remessa")]
        public string Remessa { get; set; }

        [JsonProperty("dataSaida")]
        public string DataSaida { get; set; }

        [JsonProperty("prazoEntregaPrevisto")]
        public object PrazoEntregaPrevisto { get; set; }

        [JsonProperty("valorDeclarado")]
        public string ValorDeclarado { get; set; }

        //[JsonProperty("avisoRecebimento")]
        //public string AvisoRecebimento { get; set; }

        [JsonProperty("maoPropria")]
        public bool MaoPropria { get; set; }

        [JsonProperty("dimensoes")]
        public Dimensoes Dimensoes { get; set; }

        [JsonProperty("urlRastreamento")]
        public string UrlRastreamento { get; set; }
    }

    public partial class Dimensoes
    {
        [JsonProperty("peso")]
        public string Peso { get; set; }

        [JsonProperty("altura")]
        public string Altura { get; set; }

        [JsonProperty("largura")]
        public string Largura { get; set; }

        [JsonProperty("comprimento")]
        public string Comprimento { get; set; }

        [JsonProperty("diametro")]
        public string Diametro { get; set; }
    }
}
