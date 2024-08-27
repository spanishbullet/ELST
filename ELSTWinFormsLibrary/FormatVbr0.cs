using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class FormatVbr0
{
    public static byte[] convert(string hexString)
    {
        return Enumerable.Range(0, hexString.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                         .ToArray();
    }

    public static string Extract(string vbr0HexStr)
    {
        if (vbr0HexStr.Length == 0)
        {
            return "Empty";
        }
        //else if (vbr0HexStr.Length != 512)
        //{
        //    return "Unexpected Size";
        //}

        byte[] vbr0Data = convert(vbr0HexStr);

        // Extract 4-byte values at the given offsets
        uint valueAt43 = BitConverter.ToUInt32(vbr0Data, 0x43); // Little Endian
        uint valueAt64 = BitConverter.ToUInt32(vbr0Data, 0x64); // Little Endian
        uint valueAt48 = BitConverter.ToUInt32(vbr0Data, 0x48); // Little Endian

        // Output the values
        return $"0x43: 0x{valueAt43:X8}, 0x64: 0x{valueAt64:X8},  0x48: 0x{valueAt48:X8}";
    }

}

