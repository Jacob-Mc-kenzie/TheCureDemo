using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCureDemo
{
    static class speaker
    {
        public static void Speak(char c)
        {
            Task.Run(()=> Console.Beep((int)c * 10 + 70, 4));
        }
        public static async void Speak(string words, int character_delay)
        {
            foreach (char c in words)
            {
                await Task.Delay(character_delay);
                Speak(c);
            }
        }
    }
}
