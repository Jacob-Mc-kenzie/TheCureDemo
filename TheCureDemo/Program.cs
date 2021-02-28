using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapactGraphicsV2;

namespace TheCureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CompactGraphics graphics = new CompactGraphics(120,50);
            Menu main = new IntroMenu(graphics);
            Input inp = new Input(false);
            while (true)
            {

                main.StepFrame();
                graphics.pushFrame();
            }
        }
    }
}
