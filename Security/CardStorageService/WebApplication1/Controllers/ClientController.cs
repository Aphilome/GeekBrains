using CardStorageServiceData;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using FluentValidation;
using System.Collections.Generic;
using AutoMapper;

namespace CardStorageService.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        #region Services

        private readonly IClientRepositoryService _clientRepositoryService;
        private readonly ILogger<CardController> _logger;
        private readonly IValidator<CreateClientRequest> _createClientRequestValidator;
        private readonly IMapper _mapper;

        #endregion


        #region Constructors

        public ClientController(
            ILogger<CardController> logger,
            IClientRepositoryService clientRepositoryService,
            IValidator<CreateClientRequest> createClientRequestValidator,
            IMapper mapper)
        {
            _logger = logger;
            _clientRepositoryService = clientRepositoryService;
            _createClientRequestValidator = createClientRequestValidator;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateClientRequest request)
        {
            var validationResult = _createClientRequestValidator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            try
            {
                var clientId = _clientRepositoryService.Create(_mapper.Map<Client>(request));

                return Ok(new CreateClientResponse
                {
                    ClientId = clientId
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create client error");
                return Ok(new CreateCardResponse
                {
                    ErrorCode = 912,
                    ErrorMessage = "Create client error"
                });
            }
        }

        #endregion
    }
}
