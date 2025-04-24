using System;

namespace Delegate
{
    // public delegate double Delegate1(int x, float y, double z);
    // public delegate void Delegate2(int x, float y, double z);
    // public delegate bool Delegate3(string str);

    
    class GenericDelegates
    {
        public static double addNum1(int x, float y, double z)
        {
            return x + y + z;
        }
        public static void addNum2(int x, float y, double z)
        {
            System.Console.WriteLine(x + y + z);
        }
        public static bool CheckLength(string str)
        {
            if (str.Length > 0)
            {
                return true;
            }
            return false;
        }

        static void Main()
        {
            // Delegate1 obj1=addNum1;
            // double res=obj1.Invoke(100,34.5f,193.465);
            // System.Console.WriteLine(res);

            Func<int,float,double,double> obj1=addNum1;    // When return  is there
            double res=obj1.Invoke(100,34.5f,193.465);     //---> Func Delegate both i/p and o/p parameter
            System.Console.WriteLine(res);

            // Delegate2 obj2=addNum2;
            // obj2(100,34.5f,193.465);    

            Action<int,float,double> obj2=addNum2;        // When no returning
            obj2(100,34.5f,193.465);                      //---->Action Delegate only input parameter

            // Delegate3 obj3=CheckLength;
            // bool status=obj3.Invoke("Hello");
            // System.Console.WriteLine(status);

            Predicate<string> obj3 =CheckLength;      //When return type is bool
            bool status=obj3.Invoke("Hello");         //---> Predicate Delegate only input parameter
            System.Console.WriteLine(status);
        }
    }
}