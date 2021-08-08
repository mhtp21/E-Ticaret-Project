using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(i => i.CityId).NotEmpty().WithMessage("Lütfen şehir adı yazınız");
            RuleFor(i => i.AddressDetail).NotEmpty().WithMessage("Lütfen adres detayını yazınız");
            RuleFor(i => i.AddressDetail).MinimumLength(10).WithMessage("Adres detayınız en az 10 karakterden oluşmalıdır");
            RuleFor(i => i.AddressDetail).MaximumLength(150).WithMessage("Adres detayı en fazla 150 karakterden oluşabilir.");
        }
    }
}