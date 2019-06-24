using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW2306_Dynamic_Begin_Invoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double> funcPie = new Func<double>(ReturnPie);
            IAsyncResult async = funcPie.BeginInvoke((IAsyncResult ar) =>
            {
                Console.WriteLine("after..........");

                Console.WriteLine(ar.AsyncState); // this is the "hello" parameter

                double res = funcPie.EndInvoke(ar); // pull result in callback method
                Console.WriteLine("what was the result? " + res);

            }
            , "hello");
            Thread.Sleep(3000);
        }
        static double ReturnPie()
        {
            return 3.14;
        }
    }
}
