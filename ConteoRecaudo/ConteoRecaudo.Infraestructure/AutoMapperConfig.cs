using AutoMapper;
using ConteoRecaudo.API.Models;
using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Infraestructure.Models;

namespace ConteoRecaudo.Infraestructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Register, Usuario>().ReverseMap();
            CreateMap<AuthenticationResponse, Usuario>().ReverseMap();
        }
    }
}
