namespace Calculator
{
    public class Operations
    {
        public static int Add(int x,int y)
        {
           return x+y;
        }

        public static int Sub(int x,int y)
        {
            return x-y;
        }
        

        public static int Mul(int x,int y)
        {
            return x*y;
        }
        public static double Div(int x,int y)
        {
            double ans=(double)x/y;
            return ans;
        }
        public static int Mod(int x,int y)
        {
            return x%y;
        }
    }
}