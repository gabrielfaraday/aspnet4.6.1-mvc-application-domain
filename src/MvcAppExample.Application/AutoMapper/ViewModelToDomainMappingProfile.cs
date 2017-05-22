using AutoMapper;
using MvcAppExample.Application.ViewModels;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.ValueObjects;

namespace MvcAppExample.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ContatoViewModel, Contato>()
                .ForMember(
                    c => c.Email,
                    cvm => cvm.ResolveUsing(x => new Email { Endereco = x.Email }));

            CreateMap<TelefoneViewModel, Telefone>();
        }
    }
}
