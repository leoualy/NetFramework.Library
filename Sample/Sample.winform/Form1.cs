using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Network.WinSock;

namespace Sample.winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mSocket = new SocketSample(5500);
        }


        private SocketSample mSocket;
        private void button1_Click(object sender, EventArgs e)
        {
            mSocket.Start(count =>
            {
                this.Invoke(new Action(() =>
                {
                    label1.Text = count.ToString();
                }));
            });
        }
    }
}
