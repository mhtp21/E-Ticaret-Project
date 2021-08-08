using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator:AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(i => i.CountryId).NotEmpty().WithMessage("Lütfen ülke ismini yazınız");
            RuleFor(i => i.Name).NotEmpty().WithMessage("Lütfen şehir ismi yazınız");
            RuleFor(i => i.Name).MinimumLength(4).WithMessage("Şehir ismi en az 4 karakterden oluşabilir");
            RuleFor(i => i.Name).MaximumLength(25).WithMessage("Şehir ismi en fazla 25 karakterden oluşabilir");
        }
    }
}