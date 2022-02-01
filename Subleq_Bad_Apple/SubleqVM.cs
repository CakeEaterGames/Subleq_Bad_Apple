using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subleq_Bad_Apple
{
    class VM
    {
        public int pc = 0;
        public List<int> cell;

        public Queue<int> inputs = new Queue<int>();
        public Queue<int> outputs = new Queue<int>();

        public bool pause = false;
        public bool done = false;

        public void Init(string inp)
        {
            inp = inp.Replace("\r", " ").Replace("\n", " ");
            while (inp.Contains("  "))
            {
                inp = inp.Replace("  ", " ");
            }
            inp = inp.Trim();

            cell = inp.Split(' ').Select(Int32.Parse).ToList();

            pc = 0;
            done = false;
            pause = false;

            outputs = new Queue<int>();
            inputs = new Queue<int>();

        }
 
        public void Run()
        {
            pause = false;
            while (!pause && !done)
            {
                if (pc < 0 || cell.Count < pc + 3)
                {
                    done = true;
                    break;
                }

                int A = cell[pc + 0];
                int B = cell[pc + 1];
                int C = cell[pc + 2];

                if (B == -1)
                {
                    outputs.Enqueue(cell[A]);
                    pc += 3;
                }
                else if (A == -1)
                {
                    if (inputs.Count == 0)
                    {
                        pause = true;
                        break;
                    }
                    cell[B] -= inputs.Dequeue();
                }
                else
                {
                    cell[B] -= cell[A];
                }

                if (B != -1)
                {
                    if (cell[B] <= 0)
                    {
                        pc = C;
                    }
                    else
                    {
                        pc += 3;
                    }
                }

            }
        }
    }

}
