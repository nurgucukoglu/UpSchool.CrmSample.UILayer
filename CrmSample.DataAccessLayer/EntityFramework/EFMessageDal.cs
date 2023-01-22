using CrmSample.DataAccessLayer.Abstract;
using CrmSample.DataAccessLayer.Repository;
using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.EntityFramework
{
    public class EFMessageDal: GenericRepository<Message>, IMessageDal
    {
    }
}
