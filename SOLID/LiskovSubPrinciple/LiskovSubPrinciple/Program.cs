namespace LiskovSubPrinciple
{
    public class Rectangle
    {
        public virtual int width { get; set; }
        public virtual int height { get; set; }
        public Rectangle()
        {
            
        }
        public Rectangle(int w,int h)
        {
            width = w; height = h;
        }
        public override string ToString()
        { return $"{nameof(width)}: {width}, {nameof(height)}: {height}";}
    }

    public class Square : Rectangle 
    {
        public override int width //overriding
        {
            set{ base.width = base.height = value;}
        }
        public override int height //overriding
        {
            set { base.width = base.height = value; }
        }
    }

    public class Program
    {
        static public int Area(Rectangle rc)=>rc.height*rc.width;
        static void Main(string[] args)
        {
            LSPViolate obj = new LSPViolate();
            obj.UseLSPViolate();

            Console.WriteLine("LSP");

            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine(Area(rc));
            Rectangle square = new Square();
            square.width = 2;
            Console.WriteLine(Area(square));
        }
    }
}