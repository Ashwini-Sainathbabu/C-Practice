using System;

namespace Calculator
{
    class Program
    {
        static void Main(string [] args)
        {
            Console.WriteLine("Enter the number1 :");
            int a= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number2 :");
            int b= Convert.ToInt32(Console.ReadLine());
            int op;
            do
            {
                Console.WriteLine("Enter number which you need to perform:\n 1.ADD \n 2.SUB \n 3.MUL \n 4.DIV \n 5.MOD \n 6.Exit");

                 op = Convert.ToInt32(Console.ReadLine());

               switch (op)
               {
                case 1:
                  Console.WriteLine("The sum of "+a+" and "+b+" is "+Operations.Add(a,b));
                  break;
                case 2:
                  Console.WriteLine("The difference of "+a+" and "+b+" is "+Operations.Sub(a,b));
                  break; 
                case 3:
                  Console.WriteLine("The multiple of "+a+" and "+b+" is "+Operations.Mul(a,b));
                  break;
                case 4:
                    if(b!=0)
                    {
                    Console.WriteLine("The division of "+a+" and "+b+" is "+Operations.Div(a,b));
                    }
                    else
                    {
                    Console.WriteLine("Error: Division by zero is not allowed!");
                    }
                    break;

                case 5:
                  Console.WriteLine("The modulo of "+a+" and "+b+" is "+Operations.Mod(a,b));
                  break;
                case 6:
                  Console.WriteLine("Exiting the program...");
                  break; 
                default:
                   Console.WriteLine("Enter correct number");
                   break;
               }

            }while(op!=6);
           
        }
    }
}