using AutoMapper;
using CrmSample.DTOLayer.ContactDTOs;
using CrmSample.EntityLayer.Concrete;

namespace CrmSample.UILayer.Mapping.AutoMapper
{
	//dto.larla entityleri birbirine bağlıcaz.
	public class MapProfile :Profile //profile isimli sınıf var onu kullandık ctrl. namespacei gelir
	{
		public MapProfile()
		{
			
			CreateMap<ContactAddDTO, Contact>(); // kayıt işlemi: ekrandan alıyosun entitye gönderiyosun.
			CreateMap<Contact, ContactAddDTO>(); // get yapıcaksan db.den alıcaksan kullanıcıya göstericeğin taraf dto olacağından tam tersi yazılır.

			CreateMap<ContactListDTO, Contact>();
			CreateMap<Contact, ContactListDTO>();

			CreateMap<ContactUpdateDTO, Contact>();
			CreateMap<Contact, ContactUpdateDTO>();


		}
	}
	//Burada kaynak ve hedef parametrelerini alır. 
	//Hedef bir durumda DTO iken diğerinde entity olabilir. 
	//Eğer ekleme işlemi yapılacaksa veritabanını kullandığım için
	//kaynak entity olur. Diğer durumda ekleme işlemi için değilde
	//mesela UI tarafında o modeli kullanmam gerekiyorsa bu
	//kez hedef DTO olur. O yüzden iki taraflı tanımlarız
}
