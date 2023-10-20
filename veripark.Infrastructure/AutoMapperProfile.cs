using AutoMapper;
using veripark.DataAccess.Models;
using veripark.ViewMode.Entities;

namespace veripark.Infrastructure
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Books, BooksEntity>().ReverseMap(); 
            CreateMap<Borrowe, BorrowerEntity>().ReverseMap();
            CreateMap<Customer, CustomerEntity>().ReverseMap();
            CreateMap<HolidayMaster, HolidayMasterEntity>().ReverseMap();
            CreateMap<RoleInUser, RoleInUserEntity>().ReverseMap();
            CreateMap<TransactionsDetail, TransactionsDetailEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Role, RoleEntity>().ReverseMap();

        }
    }


}
