using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Plutus.Model.Client;
using Plutus.Model.Entities;

namespace Plutus.Api.Bootstrap
{
    public static class AutoMapperFactory
    {
        public static void UseAutoMapper(this IApplicationBuilder app)
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Account, _Account>().ReverseMap();
                x.CreateMap<Receipt, _Receipt>().ReverseMap();
                x.CreateMap<Receipt, _ReceiptCreate>().ReverseMap();
                x.CreateMap<Receipt, _ReceiptUpdate>().ReverseMap();
                x.CreateMap<Category, _Category>().ReverseMap();
                x.CreateMap<Payment, _Payment>().ReverseMap();
            });
        }
    }
}
