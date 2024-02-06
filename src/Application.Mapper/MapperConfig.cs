using Application.ViewModel;
using AutoMapper;
using Domain.Model;

namespace Application.Service;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<InputTaskViewModel, TaskDomain>().ReverseMap();

        CreateMap<TaskViewModel, TaskDomain>().ReverseMap();
    }
}
