using CrmSample.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.ValidationRules
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("personel adını boş geçemezsiniz.");
            RuleFor(x => x.EmployeeSurName).NotEmpty().WithMessage("personel soyadını boş geçemezsiniz.");
            RuleFor(x => x.EmployeeName).MinimumLength(2).WithMessage("lütfen en az 2 karakter giriniz");
            RuleFor(x => x.EmployeeName).MaximumLength(20).WithMessage("lütfen en fazla 20 karakter giriniz");
            //RuleFor(neyle çalışacağın). (Flu Val metotları)
        }
    }
}
