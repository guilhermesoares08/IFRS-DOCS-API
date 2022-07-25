using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                if(resultMap.Count == 0)
                {
                    return NoContent();
                }
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

                if (resultMap.Count == 0)
                {
                    return NoContent();
                }
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
                List<FormByUserDto> resultMap = _mapper.Map<List<FormByUserDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(RequestNewFormDto model)
        {
            try
            {
                var formResult = _mapper.Map<Form>(model);
                
                _formService.Add(formResult);
                if (await _formService.SaveChangesAsync())
                {
                    return Created($"/api/form/{model.Id}", _mapper.Map<RequestNewFormDto>(model));
                }
            }
            catch (Exception ex)
            {
                string innerEx = ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RequestNewFormDto model)
        {
            try
            {
                var form = _formService.GetFormById(id);
                if (form == null) { return NotFound(); };
                model.UpdateDate = DateTime.Now;                
                _mapper.Map(model, form);
                _formService.Update(form);

                if (await _formService.SaveChangesAsync())
                {
                    return Created($"/api/form/{model.Id}", _mapper.Map<Form>(form));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{ex.Message}");
            }

            return BadRequest();
        }
    }
}
