using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubPrinciple
{
    public class Rectanglev
    {
        public int width { get; set; }
        public int height { get; set; }
        public Rectanglev()
        {

        }
        public Rectanglev(int w, int h)
        {
            width = w; height = h;
        }
        public override string ToString()
        { return $"{nameof(width)}: {width}, {nameof(height)}: {height}"; }
    }

    public class Squarev : Rectanglev
    {
        public new int width //overriding
        {
            set { base.width = base.height = value; }
        }
        public new int height //overriding
        {
            set { base.width = base.height = value; }
        }
    }

    public class LSPViolate
    {
        static public int Areav(Rectanglev rc) => rc.height * rc.width;
        public void UseLSPViolate()
        {
            Rectanglev rc = new Rectanglev(2, 3);
            Console.WriteLine(Areav(rc));
            Rectanglev square = new Squarev();
            square.width = 2;
            Console.WriteLine(Areav(square));
        }
    }
}
