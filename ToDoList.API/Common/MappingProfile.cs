using AutoMapper;
using ToDoList.Models;
using ToDoList.Models.DTO;

namespace ToDoList.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<ToDoLists, ToDoListDTO>().ReverseMap();
            CreateMap<Tasks, TaskDTO>().ReverseMap();
        }
    }
}
