using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.DataAccessLayer.Abstract
{
    public interface ITestimonialDal:IGenericDal<Testimonial>
    {
        List<Testimonial> GetLast3Testimonails();
    }
}
