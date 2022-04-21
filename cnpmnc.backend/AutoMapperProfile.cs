using cnpmnc.backend.DTOs.Course;
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
                .ForMember(src => src.Grades, act => act.Ignore())
                .ForMember(src => src.IsDeleted, act => act.Ignore())
                .ReverseMap();

            CreateMap<CourseCreateOrUpdateDTO, Course>()
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.Name))
                .ForMember(src => src.Content, act => act.MapFrom(dest => dest.Content))
                .ForMember(src => src.Detail, act => act.MapFrom(dest => dest.Detail))
                .ForMember(src => src.StartDate, act => act.MapFrom(dest => dest.StartDate))
                .ForMember(src => src.EndDate, act => act.MapFrom(dest => dest.EndDate))
                .ForMember(src => src.StudyConditions, act => act.MapFrom(dest => dest.StudyConditions))
                .ForMember(src => src.Tuition, act => act.MapFrom(dest => dest.Tuition))
                .ForMember(src => src.Id, act => act.Ignore())
                .ForMember(src => src.Grades, act => act.Ignore())
                .ForMember(src => src.IsDeleted, act => act.Ignore())
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
        }
    }
}
