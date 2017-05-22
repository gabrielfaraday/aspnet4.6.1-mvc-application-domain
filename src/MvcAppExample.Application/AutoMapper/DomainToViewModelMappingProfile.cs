using AutoMapper;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Application.ViewModels;

namespace MvcAppExample.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Contato, ContatoViewModel>()
                .ForMember(
                    cvm => cvm.Email,
                    c => c.MapFrom(x => x.Email.Endereco));

            CreateMap<Telefone, TelefoneViewModel>();
        }
    }
}
