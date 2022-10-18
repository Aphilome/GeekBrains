using CardStorageServiceData;
using CardStorageService.Models;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using FluentValidation;

namespace CardStorageService.Controllers
{
    [Authorize]
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        #region Services

        private readonly ICardRepositoryService _cardRepositoryService;
        private readonly ILogger<CardController> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCardRequest> _createCardRequestValidator;

        #endregion

        #region Constructors

        public CardController(
            ILogger<CardController> logger,
            ICardRepositoryService cardRepositoryService,
            IValidator<CreateCardRequest> createCardRequestValidator,
            IMapper mapper)
        {
            _logger = logger;
            _cardRepositoryService = cardRepositoryService;
            _createCardRequestValidator = createCardRequestValidator;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateCardRequest request)
        {
            var validationResult = _createCardRequestValidator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            try
            {
                var cardId = _cardRepositoryService.Create(_mapper.Map<Card>(request));
                return Ok(new CreateCardResponse
                {
                    CardId = cardId.ToString()
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create card error");
                return Ok(new CreateCardResponse
                {
                    ErrorCode = 1012,
                    ErrorMessage = "Create card error"
                });
            }
        }

        [HttpGet("get-by-client-id")]
        [ProducesResponseType(typeof(GetCardsResponse), StatusCodes.Status200OK)]
        public IActionResult GetByClientId([FromQuery] int clientId)
        {
            try
            {
                var cards = _cardRepositoryService.GetByClientId(clientId);
                return Ok(new GetCardsResponse
                {
                    Cards = _mapper.Map<List<CardDto>>(cards)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get cards error");
                return Ok(new GetCardsResponse
                {
                    ErrorCode = 1013,
                    ErrorMessage = "Get cards error"
                });
            }
        }

        #endregion
    }
}
