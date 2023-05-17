using AutoMapper;
using TaskManagementSystem.Application.DTOs.CheckItem;
using TaskManagementSystem.Application.DTOs.Task;
using Task = TaskManagementSystem.Domain.Task;

namespace TaskManagementSystem.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Task Mappings

        CreateMap<Task, ChangeTaskStatusDto>().ReverseMap();
        CreateMap<Task, CreateTaskDto>().ReverseMap();
        CreateMap<Task, TaskDto>().ReverseMap();
        CreateMap<Task, UpdateTaskDto>().ReverseMap();

        #endregion Task

        #region CheckItem Mappings

        CreateMap<Domain.CheckItem, ChangeCheckItemStatusDto>().ReverseMap();
        CreateMap<Domain.CheckItem, CheckItemDto>().ReverseMap();
        CreateMap<Domain.CheckItem, CreateCheckItemDto>().ReverseMap();
        CreateMap<Domain.CheckItem, UpdateCheckItemDto>().ReverseMap();

        #endregion CheckItem
    }
}