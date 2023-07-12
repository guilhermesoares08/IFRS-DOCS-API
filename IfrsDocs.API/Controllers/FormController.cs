using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.API.Extensions;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Enums;
using IfrsDocs.Domain.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
        private readonly IUserService _userService;

        public FormController(IMapper mapper, IFormService formService, IUserService userService)
        {
            _mapper = mapper;
            _formService = formService;
            _userService = userService;
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

                FormDto resultMap = _mapper.Map<FormDto>(result);

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
                var formResult = _formService.AddNewForm(model);
                if (formResult != null)
                {
                    var formResultDto = _mapper.Map<FormDto>(formResult);

                    return Created($"/api/form/{formResultDto.Id}", formResultDto);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + ex.InnerException?.Message}");
            }
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

        // PUT api/values/5
        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> Put(int id, UpdateFormStatusDto updateFormStatusDto)
        {
            try
            {
                var form = _formService.GetFormById(id);
                if (form == null) return NotFound($"Id de formulário informado '{id}' não encontrado");

                var userUpdate = _userService.GetUserById(updateFormStatusDto.UserId);
                if (userUpdate == null) return NotFound($"Usuário {updateFormStatusDto.UserId} não encontrado!");

                form.UpdateDate = DateTime.Now;
                form.Status = (FormStatus)updateFormStatusDto.Status;
                form.UpdateBy = userUpdate.Login;

                _formService.Update(form);

                if (await _formService.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<FormDto>(form));
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
