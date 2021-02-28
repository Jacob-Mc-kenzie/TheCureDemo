using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapactGraphicsV2;
using System.Timers;

namespace TheCureDemo
{
    public class MainMenu : Menu
    {
        Timer fixedUpdate;
        CustomTextBox mainTextBox;
        private bool fixedUpdateSet;
        string inputString;
        string outputString;
        public bool FixedUpdateEnabled { get { return fixedUpdateSet; } set {
                fixedUpdate.Enabled = value;
                fixedUpdateSet = value;
            } }
        public MainMenu(CompactGraphics g) : base(g)
        {
            specialRect mainrect = (new specialRect() { x = 50.PercentX(), y = 75.PercentY(), height = 6, width = 80.PercentX() }).Center();
            mainTextBox = new CustomTextBox(mainrect.RectFromSpecial());
            onPage.Add(mainTextBox);
            onPage.Add(new Textbox($"x:{mainTextBox.Bounds.x1}, y:{mainTextBox.Bounds.y1}, width: {mainTextBox.Bounds.width}, height: {mainTextBox.Bounds.height}", new Rect(10, 80, 15, 20)));
            fixedUpdateSet = false;
            fixedUpdate = new Timer(35);
            fixedUpdate.Elapsed += Fixed_Update_Cycle;
            fixedUpdate.AutoReset = true;
            //System.Threading.Thread.Sleep(2000);
            inputString = "The FitnessGram Pacer test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter Pacer test will begin in 30 seconds. Line up at the start. The running speed starts slowly, but gets faster each minute after you hear this signal *boop*. A single lap should be completed each time you hear this sound *ding*. Remember to run in a straight line, and run as long as possible. The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word start. On your mark, get ready, start. ";
            FixedUpdateEnabled = true;

        }

        private void Fixed_Update_Cycle(object sender, ElapsedEventArgs e)
        {
            if(inputString != "")
            {
                char c = string_Pop(inputString, out inputString);
                //speaker.Speak(c);
                outputString += c;
                mainTextBox.SetText(outputString);
            }
        }
        public override void StepFrame()
        {
            base.StepFrame();
            if(outputString != null)
                g.Draw(((int)outputString[outputString.Length - 1]).ToString(), ConsoleColor.White, 10, 10);
        }

        private void updateText(string newText)
        {
            outputString = "";
            inputString = newText;
        }
        private char string_Pop(string input, out string output)
        {
            char outp = input[0];
            output = input.Remove(0,1);
            return outp;
        }
    }
}
