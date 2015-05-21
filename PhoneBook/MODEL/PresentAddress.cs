using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.MODEL
{
    public class PresentAddress
    {
        public int id { set; get;}
        public string address { get; set; }
        public int postcode { get; set; }
        public string division { get; set; }
        public string district { get; set; }
        public string subdistrict { get; set; }
    }
}
