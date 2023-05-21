using AutoMapper;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Models;
using StudentClassManager.Application.Features.Student.Commands.CreateStudent;
using StudentClassManager.Application.Features.Student.Commands.UpdateStudent;

namespace StudentClassManager.Application.MappingProfiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentViewModel>().ReverseMap();
        CreateMap<CreateStudentCommand, Student>();
        CreateMap<UpdateStudentCommand, Student>();
    }
}
