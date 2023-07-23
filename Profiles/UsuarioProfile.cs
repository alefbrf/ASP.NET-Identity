using AutoMapper;
using Usuarios_API.Data.Dtos;
using Usuarios_API.Models;

namespace Usuarios_API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
