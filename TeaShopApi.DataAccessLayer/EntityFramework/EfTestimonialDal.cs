using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Concrete;
using TeaShopApi.DataAccessLayer.Context;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(TeaContext context) : base(context)
        {
        }

        public List<Testimonial> GetLast3Testimonails()
        {
            var context = new TeaContext();
            var values = context.Testimonials.OrderBy(x => x.TestimonialID).Take(3).ToList();
            return values;
        }
    }
}
