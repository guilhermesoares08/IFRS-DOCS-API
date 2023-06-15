using AutoMapper;
using IfrsDocs.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IfrsDocs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CourseController(IMapper mapper, ICourseService courseService)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAllCourses()
        {
            try
            {
                List<Course> results = _courseService.GetAllAsync().Result;
                List<CourseDto> resultMap = _mapper.Map<List<CourseDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Cursos {ex.Message}");
            }
        }
    }
}
