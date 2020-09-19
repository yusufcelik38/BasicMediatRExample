using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Business.Events
{
    public class NewProductCreatedEvent : INotification
    {
        private readonly string _productName;

        public NewProductCreatedEvent(string productName)
        {
            _productName = productName;
        }
    }
}
