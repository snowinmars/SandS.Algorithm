namespace SandS.Algorithm.Extensions.ArrayExtensionNamespace
{
    public static class ArrayExtension
    {
        public static int[] Parse(this int[] arr, int number)
        {
            int[] output = new int[10];

            const int decade = 10;
            int i = 0;
            while (number > 1)
            {
                output[i] = number % decade;
                i++;
                number /= decade;
                //decade *= 10;
            }

            return output;
        }
    }
}