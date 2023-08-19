namespace OpenClosedPrinciple
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large, Yuge
    }
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Product(string name, Color color, Size size)
        {
            if (name == null)
                throw new ArgumentNullException(paramName: nameof(name));
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ColorSpec : ISpecification<Product>
    {
        private Color color;
        public ColorSpec(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color==color;
        }
    }

    public class SizeSpec : ISpecification<Product>
    {
        private Size size;
        public SizeSpec(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class DualSpec<T> : ISpecification<T>
    {
        ISpecification<T> first,second;
        public DualSpec(ISpecification<T> first,ISpecification<T> second)
        {
            if (first == null)
                throw new ArgumentNullException(paramName: nameof(first));
            this.first = first;

            this.second = second??throw new ArgumentNullException(paramName:nameof(second));
        }
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> Items, ISpecification<Product> spec)
        {
            foreach (var item in Items)
            {
                if(spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var Tree = new Product("Tree", Color.Green, Size.Yuge);
            var Guitar = new Product("Guitar", Color.Blue, Size.Large);
            Product[] products = new Product[] { apple, Tree, Guitar };

            var pf = new BetterFilter();

            Console.WriteLine("Green products (new):");

            foreach (var p in pf.Filter(products, new ColorSpec(Color.Green)))
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("large blue products (new):");

            ColorSpec blueprods= new ColorSpec(Color.Blue);
            SizeSpec largeprods= new SizeSpec(Size.Large);
            foreach (var p in pf.Filter(products, new DualSpec<Product>(blueprods,largeprods)))
            {
                Console.WriteLine(p.Name);
            }
            
        }
    }
}