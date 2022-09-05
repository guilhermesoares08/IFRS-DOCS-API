﻿using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.API.Extensions;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Pagination;
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

        [HttpPost("getByUser")]
        [AllowAnonymous]
        public IActionResult Get(PageParams pageParams)
        {
            try
            {
                var results = _formService.GetFormsByUser(pageParams);

                if (results == null)
                {
                    return NotFound($"Formulários por usuário {pageParams.Term} não encontrados.");
                }

                if (results.Count == 0)
                {
                    return NoContent();
                }

                var resultMap = _mapper.Map<PageList<FormByUserDto>>(results);

                resultMap.PageSize = results.PageSize;
                resultMap.TotalPage = results.TotalPage;
                resultMap.CurrentPage = results.CurrentPage;
                resultMap.TotalCount = results.TotalCount;


                return Ok(resultMap);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar formulário {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
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
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar formulário {ex.Message}");
            }
            
        }

        [HttpPost("getForms")]
        [AllowAnonymous]
        public IActionResult GetForms(PageParams pageParams)
        {
            try
            {
                var results = _formService.GetForms(pageParams);

                if (results == null)
                {
                    return NotFound($"Formulários por usuário {pageParams.Term} não encontrados.");
                }

                if (results.Count == 0)
                {
                    return NoContent();
                }

                var resultMap = _mapper.Map<PageList<FormDto>>(results);

                resultMap.PageSize = results.PageSize;
                resultMap.TotalPage = results.TotalPage;
                resultMap.CurrentPage = results.CurrentPage;
                resultMap.TotalCount = results.TotalCount;

                Response.AddPagination(resultMap.CurrentPage,
                    resultMap.PageSize, resultMap.TotalCount, resultMap.TotalPage);

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
