using CrmSample.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlığı boş geçemezsiniz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yazınız");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yazınız");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçeriği boş geçemezsiniz");
        }
    }
}
