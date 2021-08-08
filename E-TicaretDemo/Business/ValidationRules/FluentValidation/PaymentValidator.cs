using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator: AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(i => i.NameOnTheCard).NotEmpty().WithMessage("Lütfen kart kullanıcı ismini yazınız");
            RuleFor(i => i.NameOnTheCard).MinimumLength(5).WithMessage("Kart üzerndeki isim en az 4 karakterden oluşabilir");
            RuleFor(i => i.NameOnTheCard).MaximumLength(40);
            RuleFor(i => i.CardNumber).NotEmpty().WithMessage("Lütfen kart numarasını yazınız");
            RuleFor(i => i.CardCvv).NotEmpty().WithMessage("Lütfen kart güvenlik numarasını yazınız");
            RuleFor(i => i.CardCvv).MaximumLength(3).WithMessage("Lütfen kart güvenlik numarasını doğru giriniz");
        }
    }
}
