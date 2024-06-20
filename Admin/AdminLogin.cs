using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAcc.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                if (txtAcc.Text == "admin")
                {
                    if (txtPass.Text == "admin")
                    {
                        Dashboard ds = new Dashboard();
                        this.Visible = false;
                        ds.Show();
                    }
                }           
            }    
        }
    }
}
