using AutoMapper;
using MvcAppExample.Application.ViewModels;
using MvcAppExample.Domain.Entities;

namespace MvcAppExample.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<TelefoneViewModel, Telefone>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
