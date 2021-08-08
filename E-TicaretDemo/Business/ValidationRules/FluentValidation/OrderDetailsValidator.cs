using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderDetailsValidator: AbstractValidator<OrderDetails>
    {
        public OrderDetailsValidator()
        {
            RuleFor(i => i.ProductId).NotEmpty();
            RuleFor(i => i.OrderId).NotEmpty();
            RuleFor(i => i.SalePrice).NotEmpty();
        }
    }
}
