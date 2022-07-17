
using IfrsDocs.Domain;

namespace WebRestaurantes.Services
{
    public class CourseService : BaseService<Course, ICourseRepository>, ICourseService
    {
        public CourseService(ICourseRepository CourseRepository) : base(CourseRepository)
        {
        }
    }
}
