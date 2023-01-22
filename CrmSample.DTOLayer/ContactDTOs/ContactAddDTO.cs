using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DTOLayer.ContactDTOs
{
	public class ContactAddDTO
	{
		//ekleme işleminde ID dışında tüm alanlar bana gerekli

		public string Name { get; set; }
		public string Mail { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
	}
}
