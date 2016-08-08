using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            CustomerLINQDataContext cd = new CustomerLINQDataContext();
            Customer c = new Customer();
            c.First_Name = text_first.Text;
            c.Last_Name = text_last.Text;
            c.Email = text_email.Text;
            c.CNIC = text_cnic.Text;
            c.Phone = text_phone.Text;
            cd.Customers.InsertOnSubmit(c);
            cd.SubmitChanges();
            MessageBox.Show("Customer Record Added");
        }

        private void cnic_changed(object sender, EventArgs e)
        {
            CustomerLINQDataContext cd = new CustomerLINQDataContext();
            Customer c = new Customer();
            var res1 = from res in cd.Customers select res.CNIC;
            foreach (var r in res1)
            {
                if (r == text_cnic.Text)
                {
                    MessageBox.Show("Record already exists!");
                    text_cnic.Focus();
                }

            }
        }

        private void cnic_leave(object sender, EventArgs e)
        {
            var regex = @"^\d{5}-\d{7}-\d{1}$";
            var match = Regex.Match(text_cnic.Text, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                 MessageBox.Show("Invalid Format! CNIC must be like this 00000-0000000-0");
                 text_cnic.Focus();
            }
                
            
        }

        private void phone_leave(object sender, EventArgs e)
        {
            var regex = @"^\d{4}-\d{7}$";
            var match = Regex.Match(text_phone.Text, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                MessageBox.Show("Invalid Format! Phone no. must be like this 0000-0000000");
                text_phone.Focus();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }
    }
}
