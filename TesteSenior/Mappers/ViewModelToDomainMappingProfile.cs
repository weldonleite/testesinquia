using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSenior.Domain.Entities;
using TesteSenior.ViewModels;

namespace TesteSenior.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<ProdutoCosifViewModel, ProdutoCosif>();
            Mapper.CreateMap<FormMovimentoViewModel, MovimentoManual>();
            Mapper.CreateMap<MovimentoManualViewModel, MovimentoManual>();
        }
    }
}