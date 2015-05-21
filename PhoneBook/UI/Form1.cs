using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhoneBook.MODEL;

namespace PhoneBook
{
    public partial class PhoneBookUI : Form
    {
        
        public PhoneBookUI()
        {
            InitializeComponent();
        }

       

   

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            dateLabel.Text = DateTime.Now.ToLongDateString();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Person aPerson = new Person();

            string name = saveNameTextBox.Text;
            string mobile = saveMobileTextBox.Text;
            string phone = savePhoneTextBox.Text;
            string fax = saveFaxTextBox.Text;
            string email = saveEmailTextBox.Text;
            string webSite = saveWebsiteTextBox.Text;
            string dateOfBirth = saveDateOfBirthMaskedTextBox.Text;
            string religion = saveReligionComboBox.Text;
            string sex = saveSexComboBox.Text;
            string bloodGroup = saveBloodGroupComboBox.Text;

            aPerson.name = name;
            aPerson.mobile = mobile;
            aPerson.phone = phone;
            aPerson.fax = fax;
            aPerson.email = email;
            aPerson.website = webSite;
            aPerson.dateOfBirth = dateOfBirth;
            aPerson.religion = religion;
            aPerson.sex = sex;
            aPerson.bloodGroup = bloodGroup;
            Division aDivision = new Division();

            PresentAddress aPresentAddress = new PresentAddress();
            aPresentAddress.address = savePresentAddressTextBox.Text;
            aPresentAddress.postcode = Convert.ToInt32(savePresentPostCodeTextBox.Text);
            aPresentAddress = savePresentDivisionComboBox.SelectedValue.ToString();
            aPresentAddress.district = savePresentDistrictComboBox.Text;
            aPresentAddress.subdistrict = savePresentSubdistrictComboBox.Text;

            aPerson.aPersonPresentAddress = aPresentAddress;

            PermanentAddress aPermanentAddress = new PermanentAddress();
            aPermanentAddress.address = savePermanentAddressTextBox.Text;
            aPermanentAddress.postcode = Convert.ToInt32(savePermanentPostcodeTextBox.Text);
            aPermanentAddress.division = savePermanentDivisionComboBox.Text;
            aPermanentAddress.district = savePermanentDistrictComboBox.Text;
            aPermanentAddress.subdistrict = savePermanentSubdistrictComboBox.Text;

            aPerson.aPesonPermanentAddress = aPermanentAddress;


        }




    }
}
