namespace VSLCSharpCodeBank
{
    public class Math
    {
        public static double CalculateAverage(int[] arr)
        {
            int sum = 0;
            foreach(int num in arr)
            {
            sum += num;
            }
            return (double)sum / arr.Length;
        }
    }
}
