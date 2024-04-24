using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class arrange
    {
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
        public byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }
        public string HexString2BinString(string hexString)
            {
                string result = string.Empty;
                foreach (char c in hexString)
                {
                    int v = Convert.ToInt32(c.ToString(), 16);
                    int v2 = int.Parse(Convert.ToString(v, 2));
                    // 去掉bai格式串中的空格，即可去掉每个4位二进制数之间的空格，
                    result += string.Format("{0:d4}", v2);
                }
                return result;
            }
        public string IntToHex(int Data)
        {//十進制轉16進制兩個字串
            String Hex_Data = "";
            try
            {
                int iTemp = Convert.ToInt32(Data.ToString());
                Hex_Data = String.Format("{0:X2}", iTemp);
            }
            catch (Exception ex)
            {
                return "值錯誤";
            }
            return Hex_Data;
        }
    }
    
}
