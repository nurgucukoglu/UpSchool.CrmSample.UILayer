using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DTOLayer.AppUserDTOs
{
	public class AppUserLoginDTO
	{
		public string Name { get; set; }
		public string PasswordHash { get; set; }
	}
}
