using BasicMediatRExample.Core.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Core.Dto.Request
{
    public class CreateProductRequest: IRequest<BaseResponse<bool>>
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
}
