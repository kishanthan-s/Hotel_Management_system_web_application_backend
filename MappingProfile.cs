using AutoMapper;
using Hotel_Management.Model;

namespace Hotel_Management
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerRegisterModel, Customer>()
                .ForMember(u => u.UserName, opt=>opt.MapFrom(m => m.Email));
        }
    }
}