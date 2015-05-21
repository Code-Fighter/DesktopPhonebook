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

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        String imgLoc = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG File(*.jpg)|*.jpg|GIF File(*.gif)|*.gif|All Files(*.*)|*.* ";
                dlg.Title = "Select Picture";
                if(dlg.ShowDialog()== DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    savePictureBox.ImageLocation = imgLoc;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int) fs.Length);


                String name;
                String mobile;
                String phone;
                String fax;
                String email;
                String website;
                String homeDistrict;
                String dateOfBirth;
                String religon;
                String sex;
                String bloodGroup;

                name = saveNameTextBox.Text;
                mobile = saveMobileTextBox.Text;
                phone = savePhoneTextBox.Text;
                fax = saveFaxTextBox.Text;
                email = saveEmailTextBox.Text;
                website = saveWebsiteTextBox.Text;
                homeDistrict = saveDistrictComboBox.Text;
                dateOfBirth = saveDataofBirthMaskedTextBox.Text;
                religon = saveReligionComboBox.Text;
                sex = saveSexComboBox.Text;
                bloodGroup = saveBloodGroupComboBox.Text;


                string connectionString = @"server=.\sqlexpress; database=phone_book_db; Integrated Security=SSPI";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string insertResult = "INSERT INTO phone_book_table(name, mobile, phone, fax, email, website, home_district, date_of_barth, religion, sex, blood_group, image)VALUES('" + name + "','" + mobile + "','" + phone + "','" + fax + "','" + email + "','" + website + "','" + homeDistrict + "','" + dateOfBirth + "','" + religon + "','" + sex + "','" + bloodGroup + "',@img)";

                SqlCommand command = new SqlCommand(insertResult, connection);
                command.Parameters.Add(new SqlParameter("@img", img));
                int numofrows = command.ExecuteNonQuery();
                MessageBox.Show("Information successfully Stored.\n Thank You!");
                connection.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                    string connectignString = @"server=.\sqlexpress; database=phone_book_db; Integrated Security=SSPI";
                    SqlConnection connection = new SqlConnection(connectignString);
                    connection.Open();

                    string queryStringView1 = "SELECT * FROM phone_book_table where name='" + searchTextBox.Text + "'";
                    SqlCommand commandview1 = new SqlCommand(queryStringView1, connection);
                    SqlDataReader tableReader1 = commandview1.ExecuteReader();

                    if (tableReader1.Read())
                    {
                        showNameTextBox.Text = tableReader1["name"].ToString();
                        showMobileTextBox.Text = tableReader1["mobile"].ToString();
                        showPhoneTextBox.Text = tableReader1["phone"].ToString();
                        showFaxTextBox.Text = tableReader1["fax"].ToString();
                        showEmailTextBox.Text = tableReader1["email"].ToString();
                        showWebsiteTextBox.Text = tableReader1["website"].ToString();
                        showHomeDistrictTextBox.Text = tableReader1["home_district"].ToString();
                        showDateOfBirthTextBox.Text = tableReader1["date_of_barth"].ToString();
                        showReligionTextBox.Text = tableReader1["religion"].ToString();
                        showSexTextBox.Text = tableReader1["sex"].ToString();
                        showBolldGroupTextBox.Text = tableReader1["blood_group"].ToString();
                        byte[] img = (byte[]) tableReader1["image"];
                        if(img==null)
                        {
                            showPictureBox.Image = null;
                        }
                        else
                        {
                            MemoryStream ms=new MemoryStream(img);
                            showPictureBox.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        messageLabel.Text = "Sorry no record found!!";
                    }

                    tableReader1.Close();
                    connection.Close();
                    connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void searchUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectignString = @"server=.\sqlexpress; database=phone_book_db; Integrated Security=SSPI";
                SqlConnection connection = new SqlConnection(connectignString);
                connection.Open();

                string queryStringView1 = "SELECT * FROM phone_book_table where name='" + searchUpdateTextBox.Text + "'";
                SqlCommand commandview1 = new SqlCommand(queryStringView1, connection);
                SqlDataReader tableReader1 = commandview1.ExecuteReader();

                if (tableReader1.Read())
                {
                    updatetNameTextBox.Text = tableReader1["name"].ToString();
                    updateMobileTextBox.Text = tableReader1["mobile"].ToString();
                    updatePhoneTextBox.Text = tableReader1["phone"].ToString();
                    updateFaxTextBox.Text = tableReader1["fax"].ToString();
                    updateEmailTextBox.Text = tableReader1["email"].ToString();
                    updateWebsiteTextBox.Text = tableReader1["website"].ToString();
                    updateHomeDistrictTextBox.Text = tableReader1["home_district"].ToString();
                    updateBirthMaskedTextBox.Text = tableReader1["date_of_barth"].ToString();
                    updateReligionTextBox.Text = tableReader1["religion"].ToString();
                    updateSexTextBox.Text = tableReader1["sex"].ToString();
                    updateBloodGroupTextBox.Text = tableReader1["blood_group"].ToString();
                }
                else
                {
                    updateMessageLabel.Text = "Sorry no record found!!";
                }

                tableReader1.Close();
                connection.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectignString = @"server=.\sqlexpress; database=phone_book_db; Integrated Security=SSPI";
                SqlConnection connection = new SqlConnection(connectignString);
                connection.Open();

                string queryStringView1 = "UPDATE phone_book_table SET name='" + updatetNameTextBox.Text + "', mobile='" + updateMobileTextBox.Text + "', phone='" + updatePhoneTextBox.Text + "', fax='" + updateFaxTextBox.Text + "', email='" + updateEmailTextBox.Text + "', website='" + updateWebsiteTextBox.Text + "', home_district='" + updateHomeDistrictTextBox.Text + "', religion='" + updateReligionTextBox.Text + "', sex='" + updateSexTextBox.Text + "', blood_group='"+  updateBloodGroupTextBox.Text+"' where name='" + searchUpdateTextBox.Text + "'";
                SqlCommand command = new SqlCommand(queryStringView1, connection);
                int numofrows = command.ExecuteNonQuery();
                MessageBox.Show("Information successfully Update.\n Thank You!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectignString = @"server=.\sqlexpress; database=phone_book_db; Integrated Security=SSPI";
                SqlConnection connection = new SqlConnection(connectignString);
                connection.Open();

                string queryStringView1 = "DELETE FROM phone_book_table WHERE name='" + deleteSearchTextBox.Text + "'";
                SqlCommand command = new SqlCommand(queryStringView1, connection);
                int numofrows = command.ExecuteNonQuery();
                deleteMessageLabel.Text = "Information successfully DELETE.\n Thank You!";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            dateLabel.Text = DateTime.Now.ToLongDateString();
        }


        private void viewAllContactButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectignString = @"server=.\sqlexpress; database=phone_book_db; Integrated Security=SSPI";
                SqlConnection connection = new SqlConnection(connectignString);
                connection.Open();

                string queryStringView1 = "SELECT * FROM phone_book_table";
                SqlCommand commandview1 = new SqlCommand(queryStringView1, connection);
                SqlDataReader tableReader1 = commandview1.ExecuteReader();

                contactDataGridView.Rows.Clear();
                if (tableReader1.Read())
                {
                    contactDataGridView.Rows.Add(tableReader1[0].ToString(), tableReader1[1].ToString(), tableReader1[2].ToString(), tableReader1[3].ToString(), tableReader1[10].ToString());
                }


                tableReader1.Close();
                connection.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
