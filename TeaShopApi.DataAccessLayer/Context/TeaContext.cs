using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.DataAccessLayer.Context
{
    public class TeaContext
    {
        public List<Drink> Drinks { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Message> Messages { get; set; }
        public List<Question>Questions  { get; set; }
    }
}
