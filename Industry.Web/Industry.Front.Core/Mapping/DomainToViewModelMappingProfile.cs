using AutoMapper;
using Industry.Domain.Entities;
using Industry.Front.Core.ViewModels;

namespace Industry.Front.Core.Mapping
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
            Mapper.CreateMap<Customer, CustomerListVM>()
                  .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<Customer, CustomerVM>()
                 .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<CustomerType, CustomerTypeVM>()
                 .ForMember(dest => dest.CustomerTypeId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<ContactInfo, ContactInfoVM>()
                  .ForMember(dest => dest.ContactInfoId, opt => opt.MapFrom(src => src.Id));
            

            Mapper.CreateMap<Shopper, ShopperListVM>()
                  .ForMember(dest => dest.ShopperId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<Shopper, ShopperVM>()
                  .ForMember(dest => dest.ShopperId, opt => opt.MapFrom(src => src.Id));

            Mapper.CreateMap<SerialBid, BidListVM>()
                  .ForMember(dest => dest.BidId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<SerialBid, BidVM>()
                  .ForMember(dest => dest.BidId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<SerialBidDetail, BidVM.BidDetailModel>()
                .ForMember(dest => dest.BidDetailId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));


        }

    }
}