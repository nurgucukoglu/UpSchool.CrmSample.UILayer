using CrmSample.BusinessLayer.Abstract;
using CrmSample.DataAccessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.Concrete
{
	//  : IGenericService<Contact> yazarsan da çalışır ama kedine özgü metotları gelmez.
	public class ContactManager : IContactService
	{
		private readonly IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void TDelete(Contact t)
		{
			throw new NotImplementedException();
		}

		public Contact TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Contact> TGetList()
		{
			throw new NotImplementedException();
		}

		public void TInsert(Contact t)
		{
			_contactDal.Insert(t);
		}

		public void TUpdate(Contact t)
		{
			throw new NotImplementedException();
		}
	}
}
