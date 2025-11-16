namespace AdventCodeLib
{
    public class Day01CaptchaSum
    {
        public static int CaptchaAdvent01(string inputData)
        {
            int sum = 0;
            char[] seps = { };

            for (int i = 0, j = 1; i < inputData.Length; i++, j++)
            {
                if (j == inputData.Length)
                {
                    j = 0;
                }
                if (inputData[i] == inputData[j])
                {
                    int x = int.Parse(inputData.Substring(i, 1));
                    sum += x;
                }
            }
            return sum;
        }

        public static int CaptchaAdvent01B(string inputData)
        {
            int sum = 0;
            char[] seps = { };

            for (int i = 0, j = inputData.Length / 2; i < inputData.Length; i++, j++)
            {
                if (j == inputData.Length)
                {
                    j = 0;
                }
                if (inputData[i] == inputData[j])
                {
                    int x = int.Parse(inputData.Substring(i, 1));
                    sum += x;
                }
            }
            return sum;
        }
    }
}
