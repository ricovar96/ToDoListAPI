using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;

namespace ToDoListAPI.Mappings
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<ToDoList, ToDoListDTO>()
                .ForMember(dest => dest.IsUrgent, opt => opt.MapFrom(src => src.IsUrgent == 1));

            CreateMap<ToDoListDTO, ToDoList>()
                .ForMember(dest => dest.IsUrgent, opt => opt.MapFrom(src => src.IsUrgent ? 1 : 0));
        }
    }
}
