using System;
using System.Collections.Generic;
using System.Text;
using BlingReportsApp.Domain.Entities;
using BlingReportsApp.Domain.ValueObjects;

namespace BlingReportsApp.Domain.Services
{
    public interface IConsultaSituacaoService
    {
        RootSituacao ConsultaSituacao(string modulo);
        List<SituacaoValue> GetSituacoes(string modulo);
    }
}
