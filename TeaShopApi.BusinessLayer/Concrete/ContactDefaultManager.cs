using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.BusinessLayer.Concrete
{
    public class ContactDefaultManager : IContactDefaultService
    {
        private readonly IContactDefaultDal _contactDefaultDal;

        public ContactDefaultManager(IContactDefaultDal contactDefaultDal)
        {
            _contactDefaultDal = contactDefaultDal;
        }

        public void TDelete(ContactDefault entity)
        {
            _contactDefaultDal.Delete(entity);
        }

        public ContactDefault TGetById(int id)
        {
           return _contactDefaultDal.GetById(id);
        }

        public List<ContactDefault> TGetListAll()
        {
            return _contactDefaultDal.GetListAll();
        }

        public void TInsert(ContactDefault entity)
        {
            _contactDefaultDal.Insert(entity);
        }

        public void TUpdate(ContactDefault entity)
        {
           _contactDefaultDal.Update(entity);
        }
    }
}
