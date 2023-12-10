using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.EntityLayer.Concrete
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string? ImageURL { get; set; }
        public string? URL { get; set; }
        public bool SocialMediaStatus { get; set; }
    }
}
