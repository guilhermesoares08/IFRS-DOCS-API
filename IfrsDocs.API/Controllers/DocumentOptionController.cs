using AutoMapper;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IfrsDocs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentOptionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentOptionService _documentOptionService;

        public DocumentOptionController(IMapper mapper, IDocumentOptionService documentOptionService)
        {
            _mapper = mapper;
            _documentOptionService = documentOptionService; 
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAllDocumentOption()
        {
            try
            {
                List<DocumentOption> results = _documentOptionService.GetAllAsync().Result;
                List<DocumentOptionDto> resultMap = _mapper.Map<List<DocumentOptionDto>>(results);
                return Ok(resultMap);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Opções de documento {ex.Message}");
            }
        }

        [HttpGet("GetByDocumentType/{documentTypeId}")]
        [AllowAnonymous]
        public IActionResult GetDocumentOptionByDocumentType(int documentTypeId)
        {
            try
            {
                IList<DocumentOption> results = _documentOptionService.GetDocumentOptionByDocumentType(documentTypeId);
                IList<DocumentOptionDto> resultMap = _mapper.Map<List<DocumentOptionDto>>(results);
                return Ok(resultMap);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Opções de documento {ex.Message}");
            }
        }
    }
}
