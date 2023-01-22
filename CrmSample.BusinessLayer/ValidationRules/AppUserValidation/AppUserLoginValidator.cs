using CrmSample.DTOLayer.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.ValidationRules.AppUserValidation
{
	public class AppUserLoginValidator : AbstractValidator<AppUserLoginDTO>
	{
		public AppUserLoginValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("mail boş geçilemez!");
			RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("şifre boş geçilemez!");
		}
	}
}
