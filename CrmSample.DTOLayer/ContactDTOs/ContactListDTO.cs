using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DTOLayer.ContactDTOs
{
	public class ContactListDTO
	{
		//listlemede sadece aşağıdakilerin gelmesini istiyorum.
		public int ContactID { get; set; }
		public string Name { get; set; }
		public string Subject { get; set; }
	}
}
