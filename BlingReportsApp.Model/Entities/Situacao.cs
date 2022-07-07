using System;
using System.Collections.Generic;
using System.Text;

namespace BlingReportsApp.Domain.Entities
{
    public class Situacao
    {
        public string id { get; set; }
        public string idHerdado { get; set; }
        public string nome { get; set; }
        public string cor { get; set; }
    }

    public class Situaco
    {
        public Situacao situacao { get; set; }
    }

    public class RetornoSituacao
    {
        public List<Situaco> situacoes { get; set; }
    }

    public class RootSituacao
    {
        public RetornoSituacao retorno { get; set; }
    }

}
