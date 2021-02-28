using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapactGraphicsV2;
using System.Timers;
namespace TheCureDemo
{
    class CustomTextBox : Widget
    {
        Timer fixedUpdate;
        Textbox text;
        MessageFrame frame;
        private bool fixedUpdateSet;
        string inputString;
        string outputString;
        public bool FixedUpdateEnabled
        {
            get { return fixedUpdateSet; }
            set
            {
                fixedUpdate.Enabled = value;
                fixedUpdateSet = value;
            }
        }
        public CustomTextBox(Rect size)
        {
            frame = new MessageFrame('=', ConsoleColor.Yellow,ConsoleColor.Black,size,DrawPoint.TopLeft);
            text = new Textbox("Placeholder Text...", new Rect(size.x1 + 1, size.x2 - 1, size.y1 + 1, size.y2 - 1));
            fixedUpdateSet = false;
            fixedUpdate = new Timer(35);
            fixedUpdate.Elapsed += Fixed_Update_Cycle;
            fixedUpdate.AutoReset = true;
            inputString = "";
            outputString = "Placeholder Text...";
        }

        private void Fixed_Update_Cycle(object sender, ElapsedEventArgs e)
        {
            if (inputString != "")
            {
                char c = string_Pop(inputString, out inputString);
                //speaker.Speak(c);
                outputString += c;
                SetText(outputString);
            }
        }


        public override void Draw(CompactGraphics g)
        {
            frame.Draw(g);
            text.Draw(g);
        }
        public void SetText(string text)
        {
            this.text.SetText(text);
        }
        public void updateText(string newText)
        {
            outputString = "";
            inputString = newText;
        }
        private char string_Pop(string input, out string output)
        {
            char outp = input[0];
            output = input.Remove(0, 1);
            return outp;
        }
    }
    class MessageFrame : Frame
    {
        int Style;
        static char[][] styleChart = new char[][] { new[] { '=', '+' }, new[] { '#', '*' }, new[] { '~', 'X' }, new[] { '?', ' ' } };
        public MessageFrame(char c, Rect r) : base(c, r)
        {
            Style = 0;
        }
        public MessageFrame(int style, Rect r) : base('=', r)
        {
            Style = style;
            if (style < 4 && style >= 0)
            {
                Style = style;
                borderchar = styleChart[style][0];
            }
            else
            {
                Style = 3;
                borderchar = styleChart[3][0];
            }
        }
        public MessageFrame(char c, ConsoleColor forcolor, ConsoleColor backcolor, Rect r, DrawPoint p) : this(c, r)
        {
            forColor = forcolor;
            this.backcolor = backcolor;
            Pin = p;
            Bounds = r.OffsetPin(Pin);
        }

        public override void Draw(CompactGraphics g)
        {
            for (int i = Bounds.x1; i <= Bounds.x2; i++)
            {
                for (int j = Bounds.y1; j <= Bounds.y2; j++)
                {
                    if ((i == Bounds.x1 || i == Bounds.x2) && (j == Bounds.y1 || j == Bounds.y2))
                    {
                        g.Draw(styleChart[Style][1], forColor, i, j);
                    }
                    else if (i == Bounds.x1 || i == Bounds.x2 || j == Bounds.y1 || j == Bounds.y2)
                    {
                        g.Draw(borderchar, forColor, i, j);
                    }
                    g.DrawBackground(backcolor, i, j);
                }
            }
        }
    }
}
