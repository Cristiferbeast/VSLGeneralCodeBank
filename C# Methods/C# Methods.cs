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
    public class StringManipulator
    {
        static string TimeConversion(string americanTime)
        {
        	string[] timeParts = americanTime.Split(' ');
            string[] hoursMinutes = timeParts[0].Split(':');
            int hours = int.Parse(hoursMinutes[0]);
            int minutes = int.Parse(hoursMinutes[1]);
            string amPmIndicator = timeParts[1];
            if (amPmIndicator.Equals("PM") && hours != 12) {
                hours += 12;
            } else if (amPmIndicator.Equals("AM") && hours == 12) {
                hours = 0;
            }
            string results =  String.Format("{0:D2}:{1:D2}", hours, minutes);
            return results;
        }
        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string centerText(string text, int spacing=80)
        {
            int totalWidth = spacing; 
            string centeredText = text.PadLeft((totalWidth + text.Length) / 2).PadRight(totalWidth);
            return centeredText;
        }
    }
}
