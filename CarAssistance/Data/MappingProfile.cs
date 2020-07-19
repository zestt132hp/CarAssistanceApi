using AutoMapper;
using CarAssistance.Models;
using Shared.Contracts.DtoModels;

namespace CarAssistance.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BodyType, BodyTypeDto>();
            CreateMap<Car, CarDto>();
            CreateMap<GearBoxes, GearBoxDto>();
            CreateMap<Tires, TiresDto>();
            CreateMap<CarCharacteristics, CarCharacteristicsDto>();
            CreateMap<Garage, GarageDto>();
            CreateMap<OilInfo, OilDto>();
            CreateMap<Users, UserDto>();
            CreateMap<Engine, EngineDto>();
            CreateMap<BodyTypeDto, BodyType>();
        }
    }
}
