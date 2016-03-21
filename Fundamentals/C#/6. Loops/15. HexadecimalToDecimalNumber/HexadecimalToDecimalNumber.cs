using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        string hexNum = Console.ReadLine();
        long decNum = 0;
        
        for (int i = 0; i < hexNum.Length; i++)
        {
            switch (hexNum [i])
            {
                case 'A': decNum = decNum + 10 * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;
                case 'B': decNum = decNum + 11 * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;
                case 'C': decNum = decNum + 12 * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;
                case 'D': decNum = decNum + 13 * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;
                case 'E': decNum = decNum + 14 * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;
                case 'F': decNum = decNum + 15 * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;
                default: decNum = decNum + (long)char.GetNumericValue(hexNum[i]) * (long)Math.Pow(16, (hexNum.Length - 1 - i));
                    break;
            }
        }
        Console.WriteLine(decNum);
    }
}

