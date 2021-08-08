using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Lütfen marka ismini yazınız");
            RuleFor(i => i.Name).MinimumLength(5).WithMessage("Marka ismi en az 5 karakterden oluşmalıdır");
            RuleFor(i => i.Name).MaximumLength(40).WithMessage("Marka ismi en fazla 40 karakterden oluşabilir.");
        }
    }
}
