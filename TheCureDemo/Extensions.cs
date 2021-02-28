using ComapactGraphicsV2;
namespace TheCureDemo
{
    public static class Extensions
    {
        public static Rect RectFromSpecial(this specialRect r)
        {
            return new Rect(r.x, r.x + r.width, r.y, r.y + r.height);
        }
        public static specialRect Center(this specialRect r)
        {
            r.x = r.x - r.width / 2;
            r.y = r.y - r.height / 2;
            return r;
        }
        public static specialRect CenterHorizontally(this specialRect r)
        {
            r.x = r.x - r.width / 2;
            return r;
        }
        public static specialRect CenterVertically(this specialRect r)
        {
            r.y = r.y - r.height / 2;
            return r;
        }

        public static int PercentX(this int percent)
        {
            return (int)((System.Console.WindowWidth / 100.0) * percent);
        }
        public static int PercentY(this int percent)
        {
            return (int)((System.Console.WindowHeight / 100.0) * percent);
        }
    }
}
