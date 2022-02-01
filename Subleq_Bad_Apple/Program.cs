using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Subleq_Bad_Apple
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
        }

        public Program()
        {
            Console.WriteLine("Please enter delay in ms");
            Console.WriteLine("(27 works best for me)");
            int delay = int.Parse(Console.ReadLine());

            StreamReader sr = new StreamReader("input.txt");
            var code = sr.ReadToEnd();

            VM vm = new VM();
            vm.Init(code);

            while (!vm.done)
            {
                vm.Run();
                StringBuilder outp = new StringBuilder();
                while (vm.outputs.Count > 0)
                {
                    outp.Append((char)vm.outputs.Dequeue());
                }
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.Write(outp);
                /*
                 
                //This is how subleq usually works
                //but for the sake of more comfortable viewing experience 
                //instead of feeding console inputs to the program 
                //we feed it 0 and sleep for a couple ms
                //and move the console pointer to reduce flickering

                var inp = Console.ReadLine();
                foreach (var c in inp)
                {
                    vm.inputs.Enqueue(c);
                }
                */
                vm.inputs.Enqueue(0);
                Thread.Sleep(delay);
            }
        }
    }
    
}
 