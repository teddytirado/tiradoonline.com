using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactsSyncNameSpace
{
    public partial class ContactsSync : Form
    {
        public ContactsSync()
        {
            InitializeComponent();

            this.Show();

            string results = string.Empty;

            clsContact contacts = new clsContact();

  


            int UserID = 1001;
            txtResults.Enabled = false;

            
            //results += contacts.DeleteDuplicateOutlookContacts();
            //txtResults.Text = results;

            //for (int x = 0; x < 2; x++)
            //{
            //    results += contacts.DeleteOutlookContacts(UserID, frmProgressBar) + Environment.NewLine + Environment.NewLine;
            //    txtResults.Text = results;

            //    results += contacts.AddNewOutlookContacts(UserID, frmProgressBar) + Environment.NewLine + Environment.NewLine;
            //    txtResults.Text = results;
            //    this.Show();


            //    string path = @"B:\www\contacts\photos\";
            //    results += contacts.ImportOutlookContacts(UserID, path, frmProgressBar) + Environment.NewLine + Environment.NewLine;
            //    txtResults.Text = results;
            //    this.Show();

            //    results += contacts.ContactsSync(UserID, frmProgressBar) + Environment.NewLine + Environment.NewLine;
            //    txtResults.Text = results;
            //    this.Show();
            //}

            txtResults.Enabled = true;

            MessageBox.Show("Outlook Contacts Export Complete", "Outlook Contacts Export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Show();

            contacts = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ContactsSync_Load(object sender, EventArgs e)
        {

        }
    }
}