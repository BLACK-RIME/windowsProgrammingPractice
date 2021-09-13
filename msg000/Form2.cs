using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace msg000
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        IntPtr HD;

        public Form2(IntPtr hd)
        {
            InitializeComponent();
            HD = hd;
        }
        public struct My_lParam
        {
            public int i;
            public string s;
        }
        //消息发送API
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        IntPtr hWnd,        // 信息发往的窗口的句柄
        int Msg,            // 消息ID
        int wParam,         // 参数1
        ref My_lParam lParam
        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
}
