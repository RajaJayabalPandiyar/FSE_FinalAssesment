using AutoMapper;
using DataLayer;
using Common.DataModel;

namespace BusinessLayer
{
    public class EntityMapper <TSource, TDestination> where TSource : class where TDestination : class
    {
        MapperConfiguration _mapperConfiguration;

        public EntityMapper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProjectModel, Project>().ReverseMap();
                cfg.CreateMap<ParentTaskModel, ParentTask>().ReverseMap();
                cfg.CreateMap<UserModel, User>().ReverseMap();
                cfg.CreateMap<TaskModel, Task>().ReverseMap();
            });           
        }

        public TDestination Translate(TSource obj)
        {
            var mapper = _mapperConfiguration.CreateMapper();
            return mapper.Map<TDestination>(obj);
        }
    }
}
