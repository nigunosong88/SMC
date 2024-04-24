using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1
{
    public class CMD//輸入控制馬達指令
    {
        public enum AddressNo
        {//控制器Address
            Id1 = 0x01,
            Id2,
            Id3
        }
        public enum FunctionCode
        {
            Code01 = 0x01,  //读取输出信号（Y），Y接点的读取(01h)
            Code02,         //读取输出信号（X），X接点的读取(02h)
            Code03,         //读取数据（D），参数及各种数据的读取，不可读取X、Y 接点讀取D接點(03h)
            Code05 = 0x05,  //强制信号输出（Y），Y 接点的 1 点写入(05h)
            Code08 = 0x08,  //回送校验 根据回送校验测试通信
            Code0F = 0x0F,  //输出信号全部写入 Y 接点全部写入
            Code10 = 0x10,  //写入数据（D） 参数及各种数据的写入，不能写入Y接点
        }
        public enum Write
        {
            Contact_state_H_NO = 0xFF,
            Contact_state_H_OFF = 0x00,
            Contact_state_L = 0x00
        }
        public enum Data
        {
            Y19 = 0x19,                 //SVON
            Y1B = 0x1B,                 //RESET
            Y1C = 0x1C,                 //SETUP
            Y30 = 0x30,                  //Input invalid flag

            /*讀取控制器*/
            ReadStartNumber_H = 0x00, //控制器读取X40～X4F(H)
            ReadStartNumber_L_40 = 0x40,//控制器读取X40～X4F(L)
            ReadPoint_H = 0x00,
            ReadPoint_L = 0x10,

            /*查滑軌位置*/
            ReadStartNumber_H_90 = 0x90,//D9000位置(H)
            ReadStartNumber_L_00 = 0x00,//D9000位置(L)
            ReadWords_H = 0x00,
            ReadWords_L = 0x02,

            /*寫入D9100*/
            WriteStartNumber_H_91 = 0x91,//D9100位置(H)
            WriteStartNumber_L_00 = 0x00,//D9100位置(L)
            WordsWritten_H_00 = 0x00,
            WordsWritten_L_01 = 0x01,
            NumberOfData_02 = 0x02,
            Word1_H = 0x01,
            Word1_L = 0x00,

            /*寫入各數據*/
            WriteStartNumber_L_02 = 0x02,//D9102位置(L)
            WordsWritten_L_10 = 0x10,
            NumberOfData_20 = 0x20,

        }
        public enum Mode { Mode_H = 0x00, }//模式  
        public enum Areaoutput
        {
            area1 = 0x00,
            area2 = 0x00,
        }
        public enum InPosition
        {
            InPosition1 = 0x00,
            InPosition2 = 0x64,
        }

        public static AddressNo Address { get; set; }
        public static FunctionCode Function { get; set; }
        public static byte mode { get; set; }
        public static void Speeed(int speed)
        {
            CMD.speed[0] = Convert.ToByte((byte)(speed / 256));
            CMD.speed[1] = Convert.ToByte((byte)(speed % 256));
        }
        public static void Position(int value)
        {
            position[0] = 0x00; position[1] = 0x00;
            if (value < 0)
            {
                position[0] = 0xFF;
                position[1] = 0xFF;
                position[2] = Convert.ToByte((value + 65536) / 256);
                position[3] = Convert.ToByte((value + 65536) % 256);
            }
            else
            {
                position[2] = Convert.ToByte(value / 256);
                position[3] = Convert.ToByte(value % 256);
            }
        }
        public static void Accelerate(int value)
        {
            CMD.accelerate[0] = Convert.ToByte((byte)(value / 256));
            CMD.accelerate[1] = Convert.ToByte((byte)(value % 256));
        }
        public static void Decelerate(int value)
        {
            CMD.decelerate[0] = Convert.ToByte((byte)(value / 256));
            CMD.decelerate[1] = Convert.ToByte((byte)(value % 256));
        }
        public static void PushingForce(int value)
        {
            CMD.pushingforce[0] = Convert.ToByte((byte)(value / 256));
            CMD.pushingforce[1] = Convert.ToByte((byte)(value % 256));
        }
        public static void TriggerLevel(int value)
        {
            CMD.tiggerlevel[0] = Convert.ToByte((byte)(value / 256));
            CMD.tiggerlevel[1] = Convert.ToByte((byte)(value % 256));
        }
        public static void Pushingspeed(int value)
        {
            CMD.pushingspeed[0] = Convert.ToByte((byte)(value / 256));
            CMD.pushingspeed[1] = Convert.ToByte((byte)(value % 256));
        }
        public static void MovingForce(int value)
        {
            CMD.movingforce[0] = Convert.ToByte((byte)(value / 256));
            CMD.movingforce[1] = Convert.ToByte((byte)(value % 256));
        }
        public static void CRC(int value)
        {
            CMD.CRC1 = Convert.ToByte((byte)(value / 256));
            CMD.CRC2 = Convert.ToByte((byte)(value % 256));
        }




        public static byte[] speed = new byte[2];
        public static byte[] position = new byte[4];
        public static byte[] accelerate = new byte[2];
        public static byte[] decelerate = new byte[2];
        public static byte[] pushingforce = new byte[2];
        public static byte[] tiggerlevel = new byte[2];
        public static byte[] pushingspeed = new byte[2];
        public static byte[] movingforce = new byte[2];
        public static byte CRC1;
        public static byte CRC2;
        public byte[] CMDTOBYTE()
        {
            byte[] tmp = new byte[] { (byte)Address, (byte)Function, (byte)Data.WriteStartNumber_H_91, (byte)Data.WriteStartNumber_L_02, (byte)Data.WordsWritten_H_00, (byte)Data.WordsWritten_L_10, (byte)Data.NumberOfData_20,
                (byte)Mode.Mode_H, mode, speed[0], speed[1], position[0], position[1], position[2], position[3], accelerate[0],accelerate[1],decelerate[0],decelerate[1],pushingforce[0],pushingforce[1],
            tiggerlevel[0],tiggerlevel[1],pushingspeed[0],pushingspeed[1],movingforce[0],movingforce[1],(byte)Areaoutput.area1,(byte)Areaoutput.area1,(byte)Areaoutput.area1,(byte)Areaoutput.area1,
            (byte)Areaoutput.area2,(byte)Areaoutput.area2,(byte)Areaoutput.area2,(byte)Areaoutput.area2,(byte)InPosition.InPosition1,(byte)InPosition.InPosition1,(byte)InPosition.InPosition1,(byte)InPosition.InPosition2,CMD.CRC2,CMD.CRC1};
            return tmp;
        }

    }
    class SMC
    {
        arrange math = new arrange();
        public byte[] ready_Y30_1 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y30, (byte)CMD.Write.Contact_state_H_NO, (byte)CMD.Write.Contact_state_L,  };//指示串行通信有效，在Y30中写入1。
        public byte[] SVON_Y19_1 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y19, (byte)CMD.Write.Contact_state_H_NO, (byte)CMD.Write.Contact_state_L,  };//伺服ON ，在SVON (Y19)中写入1。
        public byte[] SVON_Y19_0 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y19, (byte)CMD.Write.Contact_state_H_OFF, (byte)CMD.Write.Contact_state_L,  };//伺服OFF, SVON (Y19)中写入0
        public byte[] SVRE_X49_1 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code02, (byte)CMD.Data.ReadPoint_H, (byte)CMD.Data.ReadStartNumber_L_40, (byte)CMD.Data.ReadPoint_H, (byte)CMD.Data.ReadPoint_L,  };//确认SVRE ( X49 ) 变为1。【发送数据例】读出（X40-X4F）。

        public byte[] reset_Y1B_1 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y1B, (byte)CMD.Write.Contact_state_H_NO, (byte)CMD.Write.Contact_state_L,  };//RESER寫入1
        public byte[] reset_Y1B_0 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y1B, (byte)CMD.Write.Contact_state_H_OFF, (byte)CMD.Write.Contact_state_L,  };//RESER寫入0
        public byte[] back_Y1C_1 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y1C, (byte)CMD.Write.Contact_state_H_NO, (byte)CMD.Write.Contact_state_L,  };//确认SVRE ( X49 ) 变为1。【发送数据例】读出（X40-X4F）。
        public byte[] back_X4A_1 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code02, (byte)CMD.Data.ReadPoint_H, (byte)CMD.Data.ReadStartNumber_L_40, (byte)CMD.Data.ReadPoint_H, (byte)CMD.Data.ReadPoint_L,  };//假如归零动作结束，SETON (X4A)变成1。请确认SETON (X4A)是否变成1。读出（X40-X4F）。 【发送数据例】
        public byte[] back_Y1C_0 = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code05, (byte)CMD.Data.ReadStartNumber_H, (byte)CMD.Data.Y1C, (byte)CMD.Write.Contact_state_H_OFF, (byte)CMD.Write.Contact_state_L,  };//动作结束，将ETUP(Y1C)置0。
        public byte[] read = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code03, (byte)CMD.Data.ReadStartNumber_H_90, (byte)CMD.Data.ReadStartNumber_L_00, (byte)CMD.Data.ReadWords_H, (byte)CMD.Data.ReadWords_L,  };
        public byte[] start = new byte[] { (byte)CMD.AddressNo.Id1, (byte)CMD.FunctionCode.Code10, (byte)CMD.Data.WriteStartNumber_H_91, (byte)CMD.Data.WriteStartNumber_L_00, (byte)CMD.Data.WordsWritten_H_00, (byte)CMD.Data.WordsWritten_L_01, (byte)CMD.Data.NumberOfData_02, (byte)CMD.Data.Word1_H, (byte)CMD.Data.Word1_L,  };//D9100 中写入0100h，动作开始。

        public void Calculation(SerialPort serialPort1, byte[] data) {
            int temp=math.ModRTU_CRC(data, data.Length);

            List<byte> b = new List<byte>();
            b = data.ToList();
            byte temp1 = Convert.ToByte(temp / 256);
            byte temp2 = Convert.ToByte(temp % 256);
            b.Add(temp2);
            b.Add(temp1);
            data = b.ToArray();

            Send(serialPort1, data);
        }
        public byte[] GO(int value, byte mod, int speed)
        {
            CMD Go = new CMD();
            CMD.Address = CMD.AddressNo.Id1;        //Address
            CMD.Function = CMD.FunctionCode.Code10; //Function
            CMD.mode = mod;                           //ABS or INC
            CMD.Speeed(speed);                      //速度
            CMD.Position(value);                    //位置
            CMD.Accelerate(3000);
            CMD.Decelerate(3000);
            CMD.PushingForce(0);
            CMD.TriggerLevel(0);
            CMD.Pushingspeed(20);
            CMD.MovingForce(100);
            CMD.CRC(math.ModRTU_CRC(Go.CMDTOBYTE(), 39)); 
            return Go.CMDTOBYTE();
        }
        public byte[] y(int value)
        {
            return start;
        }
        public void Send(SerialPort port, byte[] sendbyte)
        {
            try
            {
                port.Write(sendbyte, 0, sendbyte.Length);
                Thread.Sleep(200);
            }
            catch (Exception)
            {

            }
        }
        public byte[] GetBytes(string HexString)
        {
            string str = HexString.Replace(" ","");
            int byteLength = str.Length / 2;
            byte[] bytes = new byte[byteLength+2];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length-2; i++)
            {
                hex = new String(new Char[] { str[j], str[j + 1] });
                bytes[i] = math.HexToByte(hex);
                j = j + 2;
            }
            int number = math.ModRTU_CRC(bytes, bytes.Length-2);
            bytes[byteLength] = Convert.ToByte(number % 256);
            bytes[byteLength+1] = Convert.ToByte(number / 256);
            
            return bytes;
        }

        
        
    }
}
