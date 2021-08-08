using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Lütfen kategori ismini yazınız");
            RuleFor(i => i.Name).MinimumLength(4).WithMessage("Kategori ismi en az 4 karakterden oluşmalıdır.");
            RuleFor(i => i.Name).MaximumLength(20).WithMessage("Kategori ismi en fazla 20 karakterden oluşabilir.");
        }
    }
}
