using BasicMediatRExample.Business.Events;
using BasicMediatRExample.Core.Data;
using BasicMediatRExample.Core.Dto.Request;
using BasicMediatRExample.Core.Dto.Response;
using BasicMediatRExample.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicMediatRExample.Business.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, BaseResponse<bool>>
    {
        private readonly IRepository<Product> _repository;
        private readonly ILogger<CreateProductHandler> _logger;
        private readonly IMediator _mediator;
        public CreateProductHandler(IRepository<Product> repository, ILogger<CreateProductHandler> logger, IMediator mediator)
        {
            _repository = repository;
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<BaseResponse<bool>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            try
            {
                var product = new Product
                {
                    CategoryId=request.CategoryId,
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid().ToString(),
                    Name=request.Name,
                    Price=request.Price
                    
                };

                await _repository.CreateAsync(product);

                response.PayLoad = true;

                await _mediator.Publish(new NewProductCreatedEvent(productName: request.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.IsSuccessful = false;
                response.ReturnMessage="An error occurred while creating the product.";
            }

            return response;
        }
    }
}
