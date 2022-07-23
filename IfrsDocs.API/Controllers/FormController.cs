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

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                List<Form> results = _formService.GetAllForms();
                List<FormDto> resultMap = _mapper.Map<List<FormDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getByUser/{userId}")]
        [AllowAnonymous]
        public IActionResult Get(int userId)
        {
            try
            {
                List<Form> results = _formService.GetFormsByUser(userId);
                List<FormDto> resultMap = _mapper.Map<List<FormDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getPendingForms/{userId}")]
        [AllowAnonymous]
        public IActionResult GetPendingForms(int userId)
        {
            try
            {
                List<Form> results = _formService.GetPendingForms(userId);
                List<FormDto> resultMap = _mapper.Map<List<FormDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(FormDto model)
        {
            try
            {
                var formResult = _mapper.Map<Form>(model);
                
                _formService.Add(formResult);
                if (await _formService.SaveChangesAsync())
                {
                    return Created($"/api/form/{model.Id}", _mapper.Map<FormDto>(model));
                }
            }
            catch (System.Exception ex)
            {
                string innerEx = ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FormDto model)
        {
            try
            {
                var rest = await _formService.GetForMBy(id);
                if (rest == null) { return NotFound(); };

                var idsAddressess = new List<int>();
                if (model.Address != null && model.Address.Count > 0)
                {
                    model.Address.ForEach(item => idsAddressess.Add(item.Id));
                    var addressess = rest.Address.Where(
                        addr => !idsAddressess.Contains(addr.Id)
                    ).ToArray();

                    if (addressess.Length > 0) _restaurantAddressService.DeleteRange(addressess);
                }
                model.UpdateDate = DateTime.Now.ToString();
                model.CreateDate = rest.CreateDate.ToString();
                _mapper.Map(model, rest);
                _restaurantService.Update(rest);

                if (await _restaurantService.SaveChangesAsync())
                {
                    return Created($"/api/restaurant/{model.Id}", _mapper.Map<RestaurantDto>(rest));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{ex.Message}");
            }

            return BadRequest();
        }
    }
}
