using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinicple
{
    public class Documentv
    {

    }

    public interface IMachinev
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
    public class OldPrinterv : IMachinev
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
        public void Print(Document d)
        {
            //
        }
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiFunctionPrinterv : IMachinev
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
    public class violated
    {
    }
}
