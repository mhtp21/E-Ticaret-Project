using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserCommentValidator:AbstractValidator<UserComment>
    {
        public UserCommentValidator()
        {
            RuleFor(i => i.UserId).NotEmpty().WithMessage("Yorum atabilmek için lütfen giriş yapın");
            RuleFor(i => i.Comment).MaximumLength(500).WithMessage("Yorum en fazla 500 karakterden oluşabilir.");
        }
    }
}
