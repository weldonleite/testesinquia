using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSenior.Domain.Entities;
using TesteSenior.ViewModels;

namespace TesteSenior.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<ProdutoCosif, ProdutoCosifViewModel>();
            Mapper.CreateMap<MovimentoManual, FormMovimentoViewModel>();
            Mapper.CreateMap<MovimentoManual, MovimentoManualViewModel>();
        }
    }
}