using BasicMediatRExample.Core.Data;
using BasicMediatRExample.Core.Dto.Request;
using BasicMediatRExample.Core.Dto.Response;
using BasicMediatRExample.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicMediatRExample.Business.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductsRequest, BaseResponse<List<ProductDto>>>
    {
        private readonly IRepository<Product> _repository;
        private readonly ILogger<GetProductHandler> _logger;

        public GetProductHandler(IRepository<Product> repository, ILogger<GetProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BaseResponse<List<ProductDto>>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<List<ProductDto>> response = new BaseResponse<List<ProductDto>>();

            try
            {
                List<ProductDto> products = (await _repository.GetWhereAsync(m => 1==1)).Select(m => new ProductDto
                {
                    CategoryId=m.CategoryId,
                    CreatedDate=m.CreatedDate,
                    Id=m.Id,
                    IsDeleted=m.IsDeleted,
                    ModifiedDate=m.ModifiedDate,
                    Name=m.Name,
                    Price=m.Price,
                    
                }).ToList();

                response.PayLoad = products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.ReturnMessage="An error occurred while getting products.";
            }

            return response;
        }
    }
}
