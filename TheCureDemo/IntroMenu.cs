using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapactGraphicsV2;
namespace TheCureDemo
{
    public class IntroMenu : Menu
    {
        int internalState = 0;
        CustomTextBox mainTextbox;
        PixelGrid Image;
        public IntroMenu(CompactGraphics g) : base(g)
        {
            int centralX = 50.PercentX();
            mainTextbox = new CustomTextBox(new Rect(5.PercentX(), 95.PercentX(), 95.PercentY() - 7, 95.PercentY()));
            Image = new PixelGrid(new Rect(centralX, centralX + 32, 50.PercentY() - 8, 50.PercentY() + 8));
            Image.PinTo(Widget.DrawPoint.Top);

            onPage.Add(mainTextbox);
            onPage.Add(Image);

            mainTextbox.updateText(TheCureGame.TextLines.IntroLines[0]);
            
        }

        public override void StepFrame()
        {
            base.StepFrame();
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    Image.DrawPixel(i, j, ConsoleColor.White);
                }
            }
        }
    }
}
