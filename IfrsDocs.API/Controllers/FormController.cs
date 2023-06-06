using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.API.Extensions;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            try
            {
                Form result = _formService.GetFormById(id);

                if (result == null)
                {
                    return NotFound($"Formulário de id {id} não encontrado");
                }

                FormByUserDto resultMap = _mapper.Map<FormByUserDto>(result);

                return Ok(resultMap);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar formulário {ex.Message}");
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
                    return Created($"/api/form/{formResult.Id}", _mapper.Map<RequestNewFormDto>(model));
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
                    return Created($"/api/form/{form.Id}", _mapper.Map<Form>(form));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_formService.DeleteForm(id))
                {
                    return Ok("Deletado");
                }
                else
                {
                    return BadRequest("Formulário não encontrado");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar formulário {ex.Message}");
            }

        }

        [Authorize]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] PageParams pageParams)
        {
            try
            {
                var results = _formService.GetForms(pageParams);

                if (results == null)
                {
                    return NotFound($"Formulários por termo {pageParams.Term} não encontrados.");
                }

                if (results.Count == 0)
                {
                    return NoContent();
                }

                var resultMap = _mapper.Map<PageList<FormDto>>(results);

                resultMap.PageSize = results.PageSize;
                resultMap.TotalPages = results.TotalPages;
                resultMap.CurrentPage = results.CurrentPage;
                resultMap.TotalCount = results.TotalCount;

                Response.AddPagination
                    (resultMap.CurrentPage,
                    resultMap.PageSize, resultMap.TotalCount,
                    resultMap.TotalPages);

                return Ok(resultMap);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar formulário {ex.Message}");
            }
        }
    }
}
