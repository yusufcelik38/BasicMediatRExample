using BasicMediatRExample.Core.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Core.Dto.Request
{
    public class GetProductsRequest : IRequest<BaseResponse<List<ProductDto>>>
    {
    }
}
