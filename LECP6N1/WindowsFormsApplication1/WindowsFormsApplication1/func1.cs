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
    class func1
    {
        SMC smc = new SMC();
        public UInt16 ModRTU_CRC(byte[] buf, int len)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {      // If the LSB is set
                        crc >>= 1;                    // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                        crc >>= 1;                    // Just shift right
                }
            }
            // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)
            return crc;
        }
        public void RunSpot(SerialPort port,int pos, int speed, int move)//move10 max5
        //                  現在位置(mm),指定速度,位移量(mm) 
        {
            byte tmp1, tmp2, move1, move2, sp1, sp2;
            sp1 = Convert.ToByte(speed / 256);
            sp2 = Convert.ToByte(speed % 256);
            int num2 = (int)(move * 100);
            tmp1 = Convert.ToByte(num2 / 256);
            tmp2 = Convert.ToByte(num2 % 256);
            byte[] tmp_1 = new byte[] { 0x01, 0x10, 0x91, 0x02, 0x00, 0x10, 0x20, 0x00, 0x02, sp1, sp2, 0x00, 0x00, tmp1, tmp2, 0x13, 0x88, 0x13, 0x88, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14
                                            , 0x00, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x64};//設定速度位置(沒crc)
            move1 = Convert.ToByte(ModRTU_CRC(tmp_1, tmp_1.Length) % 256);
            move2 = Convert.ToByte(ModRTU_CRC(tmp_1, tmp_1.Length) / 256);
            byte[] move_set = new byte[] { 0x01, 0x10, 0x91, 0x02, 0x00, 0x10, 0x20, 0x00, 0x02, sp1, sp2, 0x00, 0x00, tmp1, tmp2, 0x13, 0x88, 0x13, 0x88, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14
                                            , 0x00, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x64, move1, move2};//設定
            byte[] start_move = new byte[] { 0x01, 0x10, 0x91, 0x00, 0x00, 0x01, 0x02, 0x01, 0x00, 0x27, 0x09 };//動作開始
            byte[] end_move = new byte[] { 0x01, 0x02, 0x00, 0x40, 0x00, 0x10, 0x78, 0x12 };//可確認動作结束（已到定位範圍内）
            byte[] res1 = new byte[] { 0x01, 0x05, 0x00, 0x1C, 0xFF, 0x00, 0x4D, 0xFC };//開始歸位
            byte[] res2 = new byte[] { 0x01, 0x02, 0x00, 0x40, 0x00, 0x10, 0x78, 0x12 };//確認SETON是否變1
            byte[] res3 = new byte[] { 0x01, 0x05, 0x00, 0x1C, 0x00, 0x00, 0x0C, 0x0C };//動作結束
            try
            {
                pos = (50 - pos) / move;
                for (int i = 0; i < pos; i++) 
                { 
                    smc.Send(port, move_set);
                    Thread.Sleep(100);
                    smc.Send(port, start_move);
                    Thread.Sleep(100);
                    smc.Send(port, end_move);
                    Thread.Sleep(1000);
                }
                Thread.Sleep(500);
                smc.Send(port, res1);
                Thread.Sleep(100);
                smc.Send(port, res2);
                Thread.Sleep(100);
                smc.Send(port, res3);
                Thread.Sleep(100);
            }
            catch
            {

            }
        }
    }
}
