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
    public partial class error : Form
    {
        public error()
        {
            InitializeComponent();
        }
        public void data(string data)
        {
            Stringdata(data);
        }
        private void error_Load(object sender, EventArgs e)
        {

            label2.Text = page + "/16";
        }
        string[] DataArray = new string[16];
        public void Stringdata(string data)
        {
            DataGridViewColumn column1_0 = dataGridView1.Columns[0];
            DataGridViewColumn column1_1 = dataGridView1.Columns[1];
            DataGridViewColumn column1_2 = dataGridView1.Columns[2];
            DataGridViewColumn column2_0 = dataGridView2.Columns[0];
            DataGridViewColumn column2_1 = dataGridView2.Columns[1];
            DataGridViewColumn column2_2 = dataGridView2.Columns[2];
            dataGridView1.ScrollBars = ScrollBars.None;//不出現滾動條
            dataGridView2.ScrollBars = ScrollBars.None;
            dataGridView1.RowTemplate.Height = 20;//欄高
            dataGridView2.RowTemplate.Height = 20;
            column1_0.Width = 30;//欄寬
            column1_1.Width = 50;
            column1_2.Width = 220;
            column2_0.Width = 30;
            column2_1.Width = 50;
            column2_2.Width = 220;

            data = data.Replace(" ", "");
            try
            {
                if (Equals(data.Substring(0, 6), "010380"))
                {
                    string temp = data.Substring(6, 256);
                    string temp1 = "";
                    //textBox1.Text = temp;
                    for (int i = 1; i <= temp.Length; i++)
                    {
                        temp1 += temp[i - 1];
                        if (i % 16 == 0)
                        {
                            DataArray[(i / 16) - 1] = temp1;
                            temp1 = "";
                        }
                    }
                    tab1();
                }
            }
            catch { }
        }
        public void tab1()
        {
            int Code;
            for (int i = 0; i < DataArray[0].Length; i += 2)
                if (DataArray[0].Substring(i, 2).Equals("00"))
                {
                    dataGridView1.Rows.Add(i / 2 + 1, "", "");
                }
                else
                {
                    Code = Convert.ToInt32(DataArray[0].Substring(i, 2), 16);
                    dataGridView1.Rows.Add(i / 2 + 1, Code, ErrorCode(Code));
                }
            tab2(1);
        }
        int page = 1;
        public void tab2(int page)
        {
            int Code;
            dataGridView2.Rows.Clear();
            for (int i = 0; i < DataArray[page - 1].Length; i += 2)
            {
                if (DataArray[page - 1].Substring(i, 2).Equals("00"))
                {
                    dataGridView2.Rows.Add(i / 2 + 1, "", "");
                }
                else
                {
                    Code = Convert.ToInt32(DataArray[page - 1].Substring(i, 2), 16);
                    dataGridView2.Rows.Add(i / 2 + 1, Code, ErrorCode(Code));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public string ErrorCode(int num)
        {
            string[] clear = new string[199];
            clear[48] = "運行數據內容不正确";
            clear[49] = "系统参数的内容不正确";
            clear[50] = "指示减速不足的運行數據";
            clear[51] = "指示未登陆的運行數據";
            clear[52] = "指示超行程";
            clear[96] = "推壓時被推回";
            clear[97] = "原点复位在设定时间内未完成";
            clear[98] = "伺服 OFF 时进行运行指示 ";
            clear[99] = "原点復位未完成时DRIVE 變為ON";
            clear[103] = "原点開關方向";
            clear[106] = "绝对型通信不良";
            clear[144] = "電動機迴轉數在设定值以上";
            clear[145] = "動力電源電壓超出设定範圍";
            clear[146] = "控制器温度的规定值異常";
            clear[147] = "控制電源超出设定範圍外";
            clear[148] = "一定时间内流过较大的電流";
            clear[149] = "到达目标位置的时间超出规定值";
            clear[150] = "通信时发生異常";
            clear[192] = "编码器发生異常";
            clear[193] = "一定时间内不能检出磁极";
            clear[194] = "输出電流过高";
            clear[195] = "電流传感器发生異常";
            clear[196] = "位置偏差计数器超出计数范围";
            clear[197] = "存儲内容異常";
            clear[198] = "CPU 異常作动";

            return clear[num];
        }
    }
}
