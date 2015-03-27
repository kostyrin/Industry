using AutoMapper;
using Industry.Domain.Entities;
using Industry.Services.DTOs;

namespace Industry.Web.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<ParentDto, Parent>()
            //.ForMember(m => m.Children, o => o.Ignore()) // To avoid automapping attempt
            //.AfterMap((p, o) => { o.Children = ToISet<ChildDto, Child>(p.Children); });
            Mapper.CreateMap<Customer, CustomerListDTO>()
                  .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.CustomerTypeName, opt => opt.MapFrom(src => src.CustomerType.Name));
            Mapper.CreateMap<Customer, CustomerDTO>()
                 .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.CustomerTypeName, opt => opt.MapFrom(src => src.CustomerType.Name));

            Mapper.CreateMap<Shopper, ShopperListDTO>()
                  .ForMember(dest => dest.ShopperId, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.ShopperName, opt => opt.MapFrom(src => src.Name));
            Mapper.CreateMap<Shopper, ShopperDTO>()
                  .ForMember(dest => dest.ShopperId, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.ShopperName, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<SerialBid, BidListDTO>()
                  .ForMember(dest => dest.BidId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<SerialBid, BidDTO>()
                  .ForMember(dest => dest.BidId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<SerialBidDetail, BidDTO.BidDetailModel>()
                .ForMember(dest => dest.BidDetailId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));


        }

    }
}