using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Lütfen ürün ismini yazınız");
            RuleFor(i => i.Name).MinimumLength(4).WithMessage("Ürün ismi en az 4 karakterden oluşabilir");
            RuleFor(i => i.Name).MaximumLength(75).WithMessage("Ürün ismi en fazla 75 karakterden oluşabilir");
            RuleFor(i => i.CategoryId).NotEmpty().WithMessage("Lütfen kategori ismini yazınız");
            RuleFor(i => i.BrandId).NotEmpty().WithMessage("Lütfen marka ismini yazınız");
            RuleFor(i => i.Code).NotEmpty().WithMessage("Lütfen ürün kodunu yazınız");
            RuleFor(i => i.Code).MinimumLength(2).WithMessage("Ürün kodu en az 2 karakterden oluşabilir");
            RuleFor(i => i.Code).MaximumLength(30).WithMessage("Ürün kodu en fazla 30 karakterden oluşabilir");
            RuleFor(i => i.Description).NotEmpty().WithMessage("Lütfen ürün açıklamasını yazınız");
            RuleFor(i => i.Description).MinimumLength(10).WithMessage("Ürün açıklaması en az 10 karakterden oluşabilir");
            RuleFor(i => i.Description).MaximumLength(1000).WithMessage("Ürün açıklaması en fazla 1000 karakterden oluşabilir");
        }


    }
}