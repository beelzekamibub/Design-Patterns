using System.Security.Cryptography.X509Certificates;

namespace DependencyInversionPrinciple
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }
    public class Person
    {
        public string Name;
    }

    public interface IRelationshipService
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipService
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            IList<Person> children = new List<Person>();
            foreach (var r in relations.Where(x=>x.Item1.Name.Equals(name) && x.Item2.Equals(Relationship.Parent))) {
                children.Add(r.Item3);
                yield return r.Item3;
            }
            //return children;
        }
    }

    public class Research
    {
        public IEnumerable<Person> children;
        Relationships _relationships;
        public Research(Relationships relationships)
        {
            _relationships=relationships;
        }
        public void research(string name)
        {
            children=_relationships.FindAllChildrenOf(name);
            foreach(var c in children)
            {
                Console.WriteLine(c.Name);
            }
        }
        public Research(IRelationshipService relationshipservice,string name)
        {
            children=relationshipservice.FindAllChildrenOf(name);
            foreach (var c in children)
            {
                Console.WriteLine(c.Name);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Mary" };
            var child2 = new Person { Name = "Chris" };

            var relationships = new Relationships();

            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships,"John");
        }
    }
}