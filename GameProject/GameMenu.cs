using GameProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameProject
{
    public partial class GameMenu : Form
    {
        private string userName;
        private GameLogin FrmLogin;
        private GamePlay Frm1;

        public GameMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            SetControlImage(this, Animation.UI_Menu_03);

            foreach (Control control in Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.Black;
                }
            }
            lbNameMN.Text = lbNameMN.Text + " " + userName;
            ButtonConfig();
            //SetControlImage(lbNameMN, Animation.UI_Textbox_02);
        }
        public void getAllUserinRoom()
        {
            Frm1 = new GamePlay(FrmLogin);
            Frm1.ABC(FrmLogin.sendIDtoForm(), userName, FrmLogin.sendAllnameOtheruser());
            Frm1.Show();
        }


        public string getUsername(string s)
        {
            userName = s;
            return userName;
        }
        public void getfmrlg(GameLogin frm)
        {
            FrmLogin = frm;
        }
        public void showFrmPlayaddphong()
        {
            Frm1 = new GamePlay(userName, FrmLogin.sendIDtoForm());//tạo frmplay mới vs tên và id
            Frm1.ABC(FrmLogin.sendIDtoForm());
            Frm1.Show();
            FrmLogin.sendFrmPlay(Frm1);

            Frm1.sendFormLG(FrmLogin);
        }
        private void btn_TaoPhong_Click(object sender, EventArgs e)
        {
            PlayAnimation(btn_TaoPhong);

            FrmLogin.SendMSG("0", userName, "", "");

            showFrmPlayaddphong();

        }
        public void getNameuserother(string name)
        {
            Frm1.getNameOtheruser(name);
        }

        //làm gì mà phải trỏ về frmMenu để gữi MSG bằng frm1(frmPlay)
        public void sendMSG(string msg)
        {
            Frm1.getMSG(msg);
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void btn_Vao_Click(object sender, EventArgs e)
        {
            PlayAnimation(btn_Vao);

            //gữi thông điệp "vào phòg" với mã 1, userName và id phòng
            FrmLogin.SendMSG("1", userName, txbIDPhong.Text, "");
            getAllUserinRoom();

        }

        private void button3_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //HÀM THÊM ANIMATION CHO BUTTON
        private void PlayAnimation(Control control)
        {
            if (control is Button button)
            {
                Thread animationThread = new Thread(() => ButtonAnimation(button));
                animationThread.Start();
                animationThread.Join();
            }
        }

        private void ButtonAnimation(Button button)
        {
            int delay = 70;
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a2);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a3);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a4);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
        }

        private void ButtonConfig()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    /*CenterControl(button);*/
                    SetControlImage(button, Animation.UI_Flat_Button_Large_Press_01a1);
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.SaddleBrown;

                }
            }
        }

        private void CenterControl(Control control)
        {
            if (control.Parent != null)
            {
                int x = (control.Parent.ClientSize.Width - control.Width) / 2;
                control.Location = new Point(x, control.Location.Y);
            }
        }

        private void SetControlImage(Control control, Image image)
        {
            control.BackgroundImage = new Bitmap(image, control.Size);
            control.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
