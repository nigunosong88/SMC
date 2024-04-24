using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            comboBox1.SelectedIndex = 0;
            speedtext.Text = "" + speedBar.Value + "mm";
            datagridview();
        }
        func1 func= new func1();
        PhotoForm Photo = new PhotoForm();
        SMC smc = new SMC();
        arrange math = new arrange();
        string str = "";
        public SerialPort serialPort1;
        private void start_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////
            serialPort1 = new SerialPort(comboBox1.Text, 38400, Parity.None, 8, StopBits.One);
            Open(serialPort1);
            /////////////////////////////////////////////////////////////////////////
            start.Enabled = false;
            smc.Calculation(serialPort1,smc.ready_Y30_1);
            smc.Calculation(serialPort1,smc.SVON_Y19_1);
            smc.Calculation(serialPort1,smc.SVRE_X49_1);
            smc.Calculation(serialPort1,smc.back_Y1C_1);
            smc.Calculation(serialPort1,smc.back_X4A_1);
            smc.Calculation(serialPort1,smc.back_Y1C_0);

            network($"已開啟端口\n已連接到{comboBox1.Text}");
            /////////////////////////////////////////////////////////////////////////
            start.Enabled = false;
            close.Enabled = true;
            button3.Enabled = true;
            SVRE_0.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            comboBox1.Enabled = false;
            reset.Enabled = true;
            button4.Enabled = true;
            Thread t1 = new Thread(MyWork);
            t1.IsBackground = true;
            t1.Start();

            // 若 t 是前景執行緒，此應用程式不會結束，除非手動將它關閉;
            // 若 t 是背景執行緒，此應用程式會立刻結束

            /////////////////////////////////////////////////////////////////////////
        }
        void MyWork()
        {
            while (true)
            {
                array();
            }

        }
        private void Open(SerialPort comport)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
        }
        public void network(string a)
        {
            textBox1.Text = a + Environment.NewLine + str;
            str = textBox1.Text;
        }
        private void closebotton()
        {
            if (status_INP.Text == "0")
                groupBox1.Enabled = false;
            else
                groupBox1.Enabled = true;
        }
        private void close_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            network("已關閉端口");
            start.Enabled = true;
            close.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            comboBox1.Enabled = true;
        }
        private void SVRE_1_Click(object sender, EventArgs e)
        {
            smc.Calculation(serialPort1, smc.SVON_Y19_1);
            SVRE_1.Enabled = false;
            SVRE_0.Enabled = true;
            network("已開啟伺服");
        }

        private void SVRE_0_Click(object sender, EventArgs e)
        {
            smc.Calculation(serialPort1, smc.SVON_Y19_0);
            SVRE_1.Enabled = true;
            SVRE_0.Enabled = false;
            network("已關閉伺服");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            smc.Calculation(serialPort1,smc.back_Y1C_1);
            smc.Calculation(serialPort1,smc.back_X4A_1);
            smc.Calculation(serialPort1,smc.back_Y1C_0);
            network("正在回歸原點");
        }
        error form2;
        public void warning(object sender, EventArgs e)
        {
            byte[] data = new byte[] { 0x01, 0x03, 0x03, 0x80, 0x00, 0x40, 0x45, 0x96 };
            serialRead = "";
            smc.Send(serialPort1,data);
            if (null == form2 || form2.IsDisposed)
            {
                form2 = new error();
                form2.Show();
                form2.data(serialRead);
            }
        }
        private void speedBar_Scroll(object sender, EventArgs e)
        {
            speedtext.Text = "" + speedBar.Value + "mm";
        }

        private void gogoABS_Click(object sender, EventArgs e)
        {
            int read = (Convert.ToInt32(UpDown1.Value) * 100);
            smc.Send(serialPort1,smc.GO(read, 0x01, speedBar.Value));
            smc.Calculation(serialPort1,smc.y(read)); closebotton();
        }
        private void right_Click_1(object sender, EventArgs e)
        {
            int read = (Convert.ToInt32(numericUpDown1.Value) * 100);
            smc.Send(serialPort1,smc.GO(read, 0x02, speedBar.Value));
            smc.Calculation(serialPort1,smc.y(read)); closebotton();
        }

        private void left_Click(object sender, EventArgs e)
        {
            int read = (Convert.ToInt32(numericUpDown1.Value) * 100);
            smc.Send(serialPort1,smc.GO(-read, 0x02, speedBar.Value));
            smc.Calculation(serialPort1,smc.y(-read)); closebotton();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            smc.Calculation(serialPort1,smc.reset_Y1B_1);
            smc.Calculation(serialPort1,smc.reset_Y1B_0);
        }
        
        byte[] RB = new byte[9];
        public String serialRead;
        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (true)
            {
                try
                {
                    int b = serialPort1.ReadByte();
                    serialRead += math.IntToHex(b) + " ";
                }
                catch (Exception IO)
                {
                    break;
                }
            }
            
        }
        delegate void SetTextCallback(string text);
        public int photo;
        private void SetText(string text)
        {
            try
            {
                if (this.label3.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    if (text.Substring(0, 4) == "0103")
                    {
                        photo = Convert.ToInt32((data2.Substring(10, 2) + data2.Substring(12, 2)), 16) / 100;
                        this.label3.Text = "距離:" + Convert.ToInt32((data2.Substring(10, 2) + data2.Substring(12, 2)), 16) / 100 + "mm\r\n";
                    }
                    else
                    {
                        status_ALARM.Text = text[0].ToString();//X4F
                        status_INP.Text = text[4].ToString();//X4B
                        status_SETON.Text = text[5].ToString();//X4A
                        status_SVRE.Text = text[6].ToString();//X49
                        status_BUSY.Text = text[7].ToString();//X48
                        backcolor(); closebotton(); 
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void remove()
        {
            try
            {
                serialPort1.DiscardInBuffer();       // RX
                serialPort1.DiscardOutBuffer();      // TX
            }
            catch (Exception)
            { 
            }
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            serialRead = "";
        }
        public string D9000(bool bo)
        {
            remove();//將前面收到的資料清空

            if (bo)
            {
                smc.Calculation(serialPort1, smc.back_X4A_1);
            }
            if (!bo)
            {
                smc.Calculation(serialPort1, smc.read);
            }
            return serialRead;
        }
        bool retrunbool = true;
        string data2 = "";
        public void array()
        {
            string data="" ;
            if (retrunbool)
            {
                data = D9000(retrunbool);
            }
            else
            {
                data2 = D9000(retrunbool);
            }
            retrunbool = !retrunbool;
            string value = "";//01020200023879
            data = data.Replace(" ", "");
            data2 = data2.Replace(" ", "");

            try
            {
                if (data2.Substring(0, 4).Equals("0103"))
                {
                    SetText(data2);
                }
                if (data.Substring(0, 6) == "010202")
                {
                    value = math.HexString2BinString(data.Substring(8, 2));//data2
                    value += math.HexString2BinString(data.Substring(6, 2));//data1
                    SetText(value);
                }
            }
            catch (Exception)
            {
            }
        }
        //X4F~X40=0~15
        private void button3_Click(object sender, EventArgs e)
        {
            Photo.now = photo;
            Photo.ShowDialog();
            if (Photo.DialogResult == System.Windows.Forms.DialogResult.OK)
            {   
                func.RunSpot(serialPort1, Photo.now, Photo.spd, Photo.mov);
            }
        }
        private void backcolor()
        {
            if (status_ALARM.Text == "1")
                status_ALARM.BackColor = Color.Red;
            else
                status_ALARM.BackColor = Color.White;
            if (status_SETON.Text == "1")
                status_SETON.BackColor = Color.Blue;
            else
                status_SETON.BackColor = Color.White;
            if (status_SVRE.Text == "1")
                status_SVRE.BackColor = Color.Blue;
            else
                status_SVRE.BackColor = Color.White;
            if (status_BUSY.Text == "1")
                status_BUSY.BackColor = Color.Blue;
            else
                status_BUSY.BackColor = Color.White;
            if (status_INP.Text == "1")
                status_INP.BackColor = Color.Blue;
            else
                status_INP.BackColor = Color.White;
        }

        private void datagridview()
        {
            ABSorINC.Items.Add("ABS");
            ABSorINC.Items.Add("INC");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            string mod;
            int distance_mm,speed;
            bool yesno = true;
            for (int i = 0; i < 3; i++)
            {
                if (dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[i].Value == null) 
                {
                    MessageBox.Show("請填寫完整");
                    yesno = false;
                }
            }
            if (yesno)
            {
                byte ABSINC;
                mod = "" + dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value;
                distance_mm = Int32.Parse(""+ dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value)*100;
                speed = Int32.Parse("" + dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value);
                if (mod == "ABS")
                    ABSINC = 0x01;
                else
                    ABSINC = 0x02;
                smc.Send(serialPort1, smc.GO(distance_mm, ABSINC, speed));
                smc.Calculation(serialPort1, smc.y(0)); closebotton();
            }
        }
        
    }
}
