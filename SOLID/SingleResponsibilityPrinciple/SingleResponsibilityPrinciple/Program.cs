using System.Diagnostics;

namespace SingleResponsibilityPrinciple
{
    public class JournalSRP
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
    }

    public class Persistence
    {
        public void Save(JournalSRP journal,string filename, bool overwrite=false)
        {
            if(overwrite ||  !File.Exists(filename)) 
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }

        public static Journal Load(string filename)
        {
            return new Journal();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var j = new JournalSRP();
            j.AddEntry("i cry");
            j.AddEntry("i eat bug");
            Console.WriteLine(j);

            var p=new Persistence();
            var filename = @"D:\tmkc.txt";
            p.Save(j,filename,true);
            Process.Start(filename);
        }
    }
}