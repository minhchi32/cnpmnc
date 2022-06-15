using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.backend.Models;

namespace cnpmnc.backend
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<CourseDTO, Course>()
                .ForMember(src => src.AssignmentGrades, act => act.Ignore())
                .ReverseMap();

            CreateMap<CourseCreateOrUpdateDTO, Course>()
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.Name))
                .ForMember(src => src.Content, act => act.MapFrom(dest => dest.Content))
                .ForMember(src => src.Detail, act => act.MapFrom(dest => dest.Detail))
                .ForMember(src => src.StudyConditions, act => act.MapFrom(dest => dest.StudyConditions))
                .ForMember(src => src.Tuition, act => act.MapFrom(dest => dest.Tuition))
                .ForMember(src => src.Id, act => act.Ignore())
                .ForMember(src => src.AssignmentGrades, act => act.Ignore())
                .ReverseMap();

            CreateMap<TeacherDTO, Account>()
                            .ForMember(src => src.AccountType, act => act.Ignore())
                            .ForMember(src => src.Status, act => act.Ignore())
                            .ReverseMap();

            CreateMap<TeacherCreateOrUpdateDTO, Account>()
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.Name))
                .ForMember(src => src.Username, act => act.MapFrom(dest => dest.Username))
                .ForMember(src => src.Address, act => act.MapFrom(dest => dest.Address))
                .ForMember(src => src.IdCard, act => act.MapFrom(dest => dest.IdCard))
                .ForMember(src => src.PhoneNumber, act => act.MapFrom(dest => dest.PhoneNumber))
                .ForMember(src => src.LiteracyId, act => act.MapFrom(dest => dest.LiteracyId))
                .ForMember(src => src.AccountType, act => act.Ignore())
                .ForMember(src => src.AssignmentGrades, act => act.Ignore())
                .ForMember(src => src.Literacy, act => act.Ignore())
                .ForMember(src => src.Id, act => act.Ignore())
                .ForMember(src => src.Status, act => act.Ignore())
                .ReverseMap();

            CreateMap<AssignmentGradeDTO, AssignmentGrade>()
                            .ReverseMap();

            CreateMap<AssignmentGradeCreateOrUpdateDTO, AssignmentGrade>()
                .ForMember(src => src.CourseId, act => act.MapFrom(dest => dest.CourseId))
                .ForMember(src => src.AssignToTeacherId, act => act.MapFrom(dest => dest.AssignToTeacherId))
                .ForMember(src => src.Note, act => act.MapFrom(dest => dest.Note))
                .ForMember(src => src.Course, act => act.Ignore())
                .ForMember(src => src.Teacher, act => act.Ignore())
                .ForMember(src => src.State, act => act.Ignore())
                .ForMember(src => src.AssignDate, act => act.Ignore())
                .ForMember(src => src.Total, act => act.Ignore())
                .ReverseMap();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Course, CourseCreateOrUpdateDTO>()
                .ReverseMap();
            CreateMap<CourseDTO, CourseCreateOrUpdateDTO>()
                .ReverseMap();
            CreateMap<Course, CourseDTO>()
                .ReverseMap();

            CreateMap<Account, TeacherCreateOrUpdateDTO>()
                .ReverseMap();
            CreateMap<TeacherDTO, TeacherCreateOrUpdateDTO>()
                .ReverseMap();
            CreateMap<Account, TeacherDTO>()
                .ReverseMap();

            CreateMap<AssignmentGrade, AssignmentGradeCreateOrUpdateDTO>()
                .ReverseMap();
            CreateMap<AssignmentGradeDTO, AssignmentGradeCreateOrUpdateDTO>()
                .ReverseMap();
            CreateMap<AssignmentGrade, AssignmentGradeDTO>()
                .ReverseMap();
        }
    }
}
