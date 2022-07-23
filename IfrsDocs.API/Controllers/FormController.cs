using AutoMapper;
using IfrsDocs.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFormService _formService;

        public FormController(IMapper mapper, IFormService formService)
        {
            _mapper = mapper;
            _formService = formService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Form> results = await _formService.GetAllFormsAsync();
                List<FormDto> resultMap = _mapper.Map<List<FormDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
    }
}
