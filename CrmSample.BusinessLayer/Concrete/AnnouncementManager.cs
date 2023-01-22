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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public List<Announcement> TContainA()
        {
            throw new NotImplementedException();
        }
     
        public void TDelete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement TGetByID(int id)
        {
            return _announcementDal.GetById(id);
        }

        public Announcement TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Announcement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public void TInsert(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void TUpdate(Announcement t)
        {
            _announcementDal.Update(t);
        }

        List<Announcement> IAnnouncementService.TContainA()
        {
            return _announcementDal.ContainA();
        }
    }
}
