using AutoMapper;
using CardStorageService.Models;
using CardStorageService.Models.Requests;
using CardStorageServiceData;

namespace CardStorageService.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDto>();

            CreateMap<CreateCardRequest, Card>();
            
            CreateMap<CreateClientRequest, Client>();
        }
    }
}
