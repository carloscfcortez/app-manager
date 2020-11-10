using AutoMapper;
using AppManager.Application.DTO;
using AppManager.Domain.Entities;

namespace AppManager.Application.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public override string ProfileName => "DtoToEntityProfile";
        public DtoToEntityProfile()
        {
            CreateMap<GroupDTO, Group>();
            CreateMap<SpecieDTO, Specie>();
            CreateMap<TreeDTO, Tree>();
            CreateMap<HarvestDTO, Harvest>();

        }
    }
}
