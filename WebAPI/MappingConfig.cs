namespace WebAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Coupon, CouponCreationDTO>().ReverseMap();
            CreateMap<Coupon, CouponUpdateDTO>().ReverseMap();
            CreateMap<LocalUser, UserDTO>().ReverseMap();
            CreateMap<LocalUser, RegistrationRequestDTO>().ReverseMap();
        }
    }
}
