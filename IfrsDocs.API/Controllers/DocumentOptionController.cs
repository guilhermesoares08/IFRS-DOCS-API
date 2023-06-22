using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.Domain;
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

        [HttpGet("getAll")]
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

        [HttpGet("{documentTypeId}")]
        [AllowAnonymous]
        public IActionResult GetByDocumentType(int documentTypeId)
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
