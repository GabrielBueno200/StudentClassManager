using AutoMapper;
using StudentClassManager.Application.Features.Classes.Commands.CreateClass;
using StudentClassManager.Application.Features.Classes.Commands.UpdateClass;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.MappingProfiles;

public class ClassProfile : Profile
{
    public ClassProfile()
    {
        CreateMap<Class, ClassViewModel>().ReverseMap();
        CreateMap<CreateClassCommand, Class>();
        CreateMap<UpdateClassCommand, Class>();
    }
}