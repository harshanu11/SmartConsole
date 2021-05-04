using System.Numerics;

namespace SmartConsoleTest.Program
{
    public class ReadyToUse
    {
        public static BigInteger VeryLargeBinToDec(string value)
        {
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }

            return res;
        }
    }
}
