using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PhotoForm : Form
    {

        public int spd;//速度
        public int mov;//位移
        public int now;//現在位置
        public PhotoForm()
        {
            InitializeComponent();
            button1.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            spd = (int)numericUpDown2.Value;
            mov = (int)numericUpDown1.Value;
            if (spd == 0 && mov == 0)
            {
                MessageBox.Show("請勿填寫0");
            }
        }

        private void PhotoForm_Load_1(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 50;
            numericUpDown2.Minimum = 10;
            numericUpDown2.Maximum = 200;
            label4.Text = "" + now;
        }
    }
}
