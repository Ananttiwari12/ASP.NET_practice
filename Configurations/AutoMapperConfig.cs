using ASP.NET_tut.Models;
using AutoMapper;

namespace ASP.NET_tut.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StudentDTO, Students>().ReverseMap();

            // configure for different property names in Students and StudentDTO
            // CreateMap<StudentDTO, Students>().ForMember(n=>n.Name, opt=>opt.MapFrom(x=>x.StudentName)).ReverseMap();

            // config for ignoring some property
            // CreateMap<StudentDTO, Students>().ForMember(n=>n.Name, opt=>opt.Ignore()).ReverseMap();

            // config for replacing null with some message
            // CreateMap<StudentDTO, Students>().ReverseMap().AddTransform<string>(n=>string.IsNullOrEmpty(n)?"no add found":n);
        }
    }
    
}