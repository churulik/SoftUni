using System;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        long decNum = long.Parse(Console.ReadLine());
        string hexNum = "";
        while (decNum > 0)
        {
            long result = decNum / 16;
            long digitInHex = decNum % 16;
            decNum = result;

            switch (digitInHex)
            {
                case 10: hexNum = 'A' + hexNum; 
                    break;
                case 11: hexNum = 'B' + hexNum; 
                    break;
                case 12: hexNum = 'C' + hexNum; 
                    break;
                case 13: hexNum = 'D' + hexNum; 
                    break;
                case 14: hexNum = 'E' + hexNum; 
                    break;
                case 15: hexNum = 'F' + hexNum; 
                    break;
                default: hexNum = digitInHex + hexNum; 
                    break;                
            }            
        }
        Console.WriteLine(hexNum);
    }
}
