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

namespace GameProject
{
    public partial class History: Form
    {
        public History()
        {
            InitializeComponent();
        }

        IFirebaseClient client;
        private string history;
        private string history0;

        private void History_Load(object sender, EventArgs e)
        {

        }

        private async void buttonDesign2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("History/"+history);
            String history0= response.ResultAs<String>();
           
        }
    }
}
