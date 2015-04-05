using AutoMapper;
using Industry.Domain.Entities;
using Industry.Front.Core.ViewModels;

namespace Industry.Front.Core.Mapping
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

            Mapper.CreateMap<ShopperVM, Shopper>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ShopperId));

            Mapper.CreateMap<BidVM, SerialBid>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BidId));

            Mapper.CreateMap<CustomerVM, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
        }
    }
}