using AutoMapper;
using CarAssistance.Models;
using CarAssistance.Models.DTO;

namespace CarAssistance.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BodyType, BodyTypeDto>();
            CreateMap<Car, CarDto>();
            CreateMap<GearBox, GearBoxDto>();
            CreateMap<Tires, TiresDto>();
            CreateMap<CarCharacteristics, CarCharacteristicsDto>();
            CreateMap<Garage, GarageDto>();
            CreateMap<Oil, OilDto>();
            CreateMap<Users, UserDto>();
            CreateMap<Engine, EngineDto>();
        }
    }
}
