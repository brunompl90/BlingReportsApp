using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BlingReportsApp.Application.Services;
using BlingReportsApp.Domain.Services;

namespace BlingReportsApp.Application.Extensions
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IConsultaSituacaoService, ConsultaSituacaoService>();
            service.AddScoped<IConsultaPedidoService, ConsultaPedidoService>();
            service.AddScoped<IConsultaProdutoService, ConsultaProdutoService>();
            return service;
        }
    }
}
