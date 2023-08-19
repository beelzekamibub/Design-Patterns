using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public enum Colorv
    {
        Red,Green,Blue
    }
    public enum Sizev
    {
        Small,Medium,Large,Yuge
    }
    public class Productv
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Productv(string name,Color color, Size size)
        {
            if(name==null)
                throw new ArgumentNullException(paramName:nameof(name));
            Name = name;
            Color = color;
            Size = size;
        }
    }
    public class ProductFilterv
    {
        public  IEnumerable<Product> FilterBySizev(IEnumerable<Product> products,Size size) 
        {
            foreach(Product product in products)
            {
                if(product.Size == size)
                    yield return product;
            }
        }//to filter by color we have to come back to this class and modify this class, therefor it was not closed for editing 
        public  IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Color == color)
                    yield return product;
            }
        }
        //now if we have to filter by size and color we have to create a new function, as we dont have a generalized
        public IEnumerable<Product> FilterByColorandSize(IEnumerable<Product> products, Color color,Size size)
        {
            foreach (Product product in products)
            {
                if (product.Color == color && product.Size==size)
                    yield return product;
            }
        }
    }
    public class OpenCloseViolated
    {
        public void UseOpenClosedViolated() 
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var Tree = new Product("Tree", Color.Green, Size.Yuge);
            var Guitar = new Product("Guitar", Color.Red, Size.Large);
            Product[] products= new Product[]{apple, Tree, Guitar};
            var pf = new ProductFilterv();
            Console.WriteLine("Green products (old):");
            foreach(var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
