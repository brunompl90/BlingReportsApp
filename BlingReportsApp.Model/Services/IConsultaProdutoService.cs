using System;
using System.Collections.Generic;
using System.Text;
using BlingReportsApp.Domain.Entities;

namespace BlingReportsApp.Domain.Services
{
    public interface IConsultaProdutoService
    {
        RootProduto ConsultaProduto(string codigo);
    }
}
