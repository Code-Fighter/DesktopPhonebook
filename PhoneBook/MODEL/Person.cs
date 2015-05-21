using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.MODEL
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }

        public string email { get; set; }
        public string website { get; set; }
        public string dateOfBirth { get; set; }
        public  string religion { get; set; }
        public string sex { get; set; }
        public string bloodGroup { get; set; }

        public PermanentAddress aPesonPermanentAddress = new PermanentAddress();
        public Division aPermanentDivision = new Division();
        public District aPermanentDistrict = new District();
        public Subdistrict aPermanentSubdistrict = new Subdistrict();

        public PresentAddress aPersonPresentAddress = new PermanentAddress();
        public Division aPresentDivision = new Division();
        public District aPresentDistrict = new District();
        public Subdistrict APresentSubdistrict = new Subdistrict();

        }
}
