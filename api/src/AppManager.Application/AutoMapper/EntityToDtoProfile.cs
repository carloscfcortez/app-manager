using AutoMapper;
using AppManager.Application.DTO;
using AppManager.Domain.Entities;

namespace AppManager.Application.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public override string ProfileName => "EntityToDtoProfile";
        public EntityToDtoProfile()
        {
            CreateMap<Group, GroupDTO>();
            CreateMap<Specie, SpecieDTO>();
            CreateMap<Tree, TreeDTO>();
            CreateMap<Harvest, HarvestDTO>();
        }
    }
}
