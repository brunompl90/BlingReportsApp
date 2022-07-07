using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BlingReportsApp.Domain.Entities
{
    
    public partial class RootProduto
    {
        [JsonProperty("retorno")]
        public RetornoProduto Retorno { get; set; }
    }

    public partial class RetornoProduto
    {
        [JsonProperty("produtos")]
        public ProdutoElement[] Produtos { get; set; }
    }

    public partial class ProdutoElement
    {
        [JsonProperty("produto")]
        public ProdutoProduto Produto { get; set; }
    }

    public partial class ProdutoProduto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        [JsonProperty("preco")]
        public string Preco { get; set; }

        [JsonProperty("precoCusto")]
        public string PrecoCusto { get; set; }

        [JsonProperty("descricaoCurta")]
        public string DescricaoCurta { get; set; }

        [JsonProperty("descricaoComplementar")]
        public string DescricaoComplementar { get; set; }

        [JsonProperty("dataInclusao")]
        public string DataInclusao { get; set; }

        [JsonProperty("dataAlteracao")]
        public string DataAlteracao { get; set; }

        [JsonProperty("imageThumbnail")]
        public Uri ImageThumbnail { get; set; }

        [JsonProperty("urlVideo")]
        public Uri UrlVideo { get; set; }

        [JsonProperty("nomeFornecedor")]
        public string NomeFornecedor { get; set; }

        [JsonProperty("codigoFabricante")]
        public string CodigoFabricante { get; set; }

        [JsonProperty("marca")]
        public string Marca { get; set; }

        [JsonProperty("class_fiscal")]
        public string ClassFiscal { get; set; }

        [JsonProperty("cest")]
        public string Cest { get; set; }

        [JsonProperty("origem")]
        public string Origem { get; set; }

        [JsonProperty("idGrupoProduto")]
        public string IdGrupoProduto { get; set; }

        [JsonProperty("linkExterno")]
        public string LinkExterno { get; set; }

        [JsonProperty("observacoes")]
        public string Observacoes { get; set; }

        [JsonProperty("grupoProduto")]
        public object GrupoProduto { get; set; }

        [JsonProperty("garantia")]
        public string Garantia { get; set; }

        [JsonProperty("descricaoFornecedor")]
        public string DescricaoFornecedor { get; set; }

        [JsonProperty("idFabricante")]
        public string IdFabricante { get; set; }

        [JsonProperty("categoria")]
        public Categoria Categoria { get; set; }

        [JsonProperty("pesoLiq")]
        public string PesoLiq { get; set; }

        [JsonProperty("pesoBruto")]
        public string PesoBruto { get; set; }

        [JsonProperty("estoqueMinimo")]
        public string EstoqueMinimo { get; set; }

        [JsonProperty("estoqueMaximo")]
        public string EstoqueMaximo { get; set; }

        [JsonProperty("gtin")]
        public string Gtin { get; set; }

        [JsonProperty("gtinEmbalagem")]
        public string GtinEmbalagem { get; set; }

        [JsonProperty("larguraProduto")]
        public string LarguraProduto { get; set; }

        [JsonProperty("alturaProduto")]
        
        public string AlturaProduto { get; set; }

        [JsonProperty("profundidadeProduto")]
       
        public string ProfundidadeProduto { get; set; }

        [JsonProperty("unidadeMedida")]
        public string UnidadeMedida { get; set; }

        [JsonProperty("itensPorCaixa")]
        public long ItensPorCaixa { get; set; }

        [JsonProperty("volumes")]
        public long Volumes { get; set; }

        [JsonProperty("localizacao")]
        public string Localizacao { get; set; }

        [JsonProperty("crossdocking")]
       
        public string Crossdocking { get; set; }

        [JsonProperty("condicao")]
        public string Condicao { get; set; }

        [JsonProperty("freteGratis")]
        public string FreteGratis { get; set; }

        [JsonProperty("producao")]
        public string Producao { get; set; }

        [JsonProperty("dataValidade")]
        public string DataValidade { get; set; }

        [JsonProperty("spedTipoItem")]
        public string SpedTipoItem { get; set; }

        [JsonProperty("estrutura")]
        public Estrutura[] Estrutura { get; set; }
    }

    public partial class Categoria
    {
        [JsonProperty("id")]
        
        public long Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }
    }

    public partial class Estrutura
    {
        [JsonProperty("componente")]
        public Componente Componente { get; set; }
    }

    public partial class Componente
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("quantidade")]
        public string Quantidade { get; set; }
    }
}
