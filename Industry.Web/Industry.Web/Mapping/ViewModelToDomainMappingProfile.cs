using AutoMapper;
using Industry.Domain.Entities;
using Industry.Services.DTOs;

namespace Industry.Web.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            //TODO Здесь мапим только *DTO!!!!!!!!

            Mapper.CreateMap<ShopperDTO, Shopper>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ShopperId));

            Mapper.CreateMap<BidDTO, SerialBid>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BidId));
        }
    }
}