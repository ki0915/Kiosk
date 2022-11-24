using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk_kms.View
{
    public class Food
    {
        public string category { get; set; }
        public string imagePath { get; set; }
        public string name { get; set; }

        public int price { get; set; }

        public static explicit operator Food((object, object, object, object) v)
        {
            throw new NotImplementedException();
        }
    }
}
