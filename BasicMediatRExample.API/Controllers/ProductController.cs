using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicMediatRExample.Core.Dto.Request;
using BasicMediatRExample.Core.Dto.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicMediatRExample.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("createProduct")]

        public async Task<ActionResult<string>> CreateProductAsync([FromBody] CreateProductRequest createProductRequest)
        {
            BaseResponse<bool> createResponse = await _mediator.Send(createProductRequest);

            if (createResponse.IsSuccessful)
            {
                return Created("...", null);
            }
            else
            {
                return BadRequest(createResponse.ReturnMessage);
            }
        }
        [HttpGet]
        [Route("getProduct")]

        public async Task<ActionResult<string>> GetProduct()
        {
            BaseResponse<List<ProductDto>> getProductResponse = await _mediator.Send(new GetProductsRequest());

            if (getProductResponse.IsSuccessful)
            {
                return Ok(getProductResponse.PayLoad);
            }
            else
            {
                return BadRequest(getProductResponse.ReturnMessage);
            }
        }
    }
}
