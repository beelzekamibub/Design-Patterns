namespace InterfaceSegregationPrinicple
{
    public class Document
    {

    }
    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IDualFunction : IPrinter, IScanner//....
    {

    }
    public class DualFunctionPrinter : IDualFunction
    {
        IPrinter _printer;
        IScanner _scanner;
        public DualFunctionPrinter(IPrinter printer,IScanner scanner)
        {
            if (printer == null) throw new ArgumentNullException(paramName:nameof(printer));
            if (scanner == null) throw new ArgumentNullException(paramName:nameof(scanner));
            _printer = printer;
            _scanner = scanner; 
        }
        public void Print(Document d)
        {
            _printer.Print(d);//decorator pattern
        }

        public void Scan(Document d)
        {
            _scanner.Scan(d);
        }
    }
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
    public class OldPrinter : IPrinter,IScanner
    {
        public void Print(Document d)
        {
            //
        }
        public void Scan(Document d)
        {
            //
        }
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}