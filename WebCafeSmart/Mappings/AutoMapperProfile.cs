using AutoMapper;
using WebCafeSmart.DataAccess;
using WebCafeSmart.DTOS;

namespace WebCafeSmart.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Caracteristica
            CreateMap<Caracteristica, CaracteristicaDTO>().ReverseMap();

            //Rol
            CreateMap<Rol, RolDTO>().ReverseMap();

            //Tipo
            CreateMap<Tipo, TipoDTO>().ReverseMap();

            //Usuario
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}
