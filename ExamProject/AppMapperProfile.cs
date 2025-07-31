using AutoMapper;
using ExamProject.Dtos;
using ExamProject.Models;
namespace ExamProject
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            // Add your mapping configurations here
            // CreateMap<Source, Destination>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<ClassDto, Class>();
            CreateMap<StudentDto, Student>();
            CreateMap<StudentAnswerDto, StudentAnswer>();
            CreateMap<TeacherQaDto, TeachertQa>();
            CreateMap<QuestionModeDto, QuestionMode>();
            CreateMap<SubjectDto, Subject>();
            
        }
    }
    
}
