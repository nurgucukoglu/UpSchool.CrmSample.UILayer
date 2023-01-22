using CrmSample.DataAccessLayer.Abstract;
using CrmSample.DataAccessLayer.Concrete;
using CrmSample.DataAccessLayer.Repository;
using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.EntityFramework
{
    public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal //sondaki IAnnouncementDal'ı ilerle entitye özgü method yazmak için çağırdık. çağırmadan da yazmıcaksan kullanabilirsin.
    {
        public List<Announcement> ContainA()
        {
            using (var context = new Context())
            {
                var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
                return values;
            }
        }
    }
}
