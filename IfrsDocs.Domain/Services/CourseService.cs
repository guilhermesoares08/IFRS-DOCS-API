
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class CourseService : BaseService<Course, ICourseRepository>, ICourseService
    {
        public CourseService(ICourseRepository CourseRepository) : base(CourseRepository)
        {
        }
    }
}
