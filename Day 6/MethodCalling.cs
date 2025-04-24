
namespace method
{
    // public delegate void addDelegate(int a,int b);
    // public delegate void subDelegate(int a,int b);   ---> Delegate


    public delegate void AddSubDelegate(int a,int b); //Multi cast delegate

    class MethodCalling
    {
        public void addNum(int a, int b) //non static method
        {
            System.Console.WriteLine($"Add {a} and {b} gives {a + b}");
        }
        public static void subNum(int a, int b) //static method
        {
            System.Console.WriteLine($"Sub {a} and {b} gives {a - b}");
        }
        public static void Main()
        {
            MethodCalling call = new MethodCalling(); //instance of class
            // call.addNum(2, 4);           --->calling non static method
            // MethodCalling.subNum(2, 4);  --->calling static method

            // addDelegate ad=new addDelegate(call.addNum); --->Instance of delegate for add method
            // subDelegate sb=new subDelegate(MethodCalling.subNum); --->Instance of delegate for sub method

            // ad(2,3); 
            // sb.Invoke(2,3); ---> Invoking method through the delegate

            AddSubDelegate addsub = call.addNum;
            addsub+=MethodCalling.subNum; // Multi-cast delegate
            
            addsub.Invoke(2,3); //Invoking both add and mul method at one invoking
        }
    }
}