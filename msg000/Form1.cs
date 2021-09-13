using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace msg000
{
    public partial class Form1 : Form
    {
        public const int USER = 0x500;
        public const int MYMESSAGE = USER + 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this.Handle);
            f.Show();
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //接收自定义消息MYMESSAGE，并显示其参数
                case MYMESSAGE:

                    Form2.My_lParam ml = new Form2.My_lParam();
                    Type t = ml.GetType();
                    ml = (Form2.My_lParam)m.GetLParam(t);
                    label1.Text = ml.s;

                    //SendCustomMessage.SENDDATASTRUCT myData = new SendCustomMessage.SENDDATASTRUCT();//这是创建自定义信息的结构
                    //Type mytype = myData.GetType();
                    //myData = (SendCustomMessage.SENDDATASTRUCT)m.GetLParam(mytype);//这里获取的就是作为LParam参数发送来的信息的结构
                    //textBox1.Text = myData.lpData; //显示收到的自定义信息
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }

        }
    }
}
