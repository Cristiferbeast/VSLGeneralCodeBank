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
        public static double Circumference(int radius)
        {
            double Pi = 3.141592653589793238462643383279502884197; 
            return Pi * 2 * radius;
        }
    }
}
