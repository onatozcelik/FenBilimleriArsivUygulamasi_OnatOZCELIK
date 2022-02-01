using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neodynamic.SDK.Printing;

namespace BarkodeProjectV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadform(new YazdirmaArayuz());
           
        }

        public void loadform(object Form)
        {
            if (this.mainPanel.Controls.Count>0)
            {
                this.mainPanel.Controls.RemoveAt(0);

            }

            Form f = Form as Form;
            f.TopLevel = false;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {


             


        }

        private void yazdırmaArayuzbtn_Click(object sender, EventArgs e)
        {
            loadform(new YazdirmaArayuz());
        }

        private void yeniKayitbtn_Click(object sender, EventArgs e)
        {
            loadform(new YeniKayit());
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
