using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //memento
        }
        public void ReomveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        public void Save(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public static Journal Load(string filename)
        {
            return new Journal();
        }
    }
    public class NotSRP
    {
        public void journalUse()
        {
            var j = new Journal();
            j.AddEntry("i cry");
            j.AddEntry("i eat bug");
            Console.WriteLine(j);
        }
    }
}
