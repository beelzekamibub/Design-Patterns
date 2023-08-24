using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public enum Relationshipv
    {
        Parent,
        Child,
        Sibling
    }
    public class Personv
    {
        public string Name;
    }

    //the relationships are the low level parts of the system
    public class Relationshipsv
    {
        private List<(Personv, Relationshipv, Personv)> relations = new List<(Personv, Relationshipv, Personv)>();
        //we can have an api to add and get relationships
        public void AddParentAndChild(Personv parent, Personv child)
        {
            relations.Add((parent, Relationshipv.Parent, child));
            relations.Add((child, Relationshipv.Child, parent));
        }
        public List<(Personv, Relationshipv, Personv)> Relations => relations; //property getter for the field
    }

    //lets say we have another class that uses this api
    //if we want research to have access to some internal private members of the low level module we can define it in the ctor
    public class Researchv
    {
        public Researchv(Relationshipsv relationships)
        {
            var relations=relationships.Relations;
            foreach(var r in relations.Where(
                x=>x.Item1.Name=="John" && 
                x.Item2==Relationshipv.Parent
            ))
            {
                Console.WriteLine($"john has a child named {r.Item3.Name}");
            }
            //whats wrong with this is that we are accessing the low level modules data store directly
            //this causes strong coupling between the two class if we change the data store from tuple to a list
            //we have to change the code in this class as well
        }
        public void research()
        {
           
        }
    }

    public class Violated
    {
        public void violated()
        {
            var parent = new Personv { Name = "John" };
            var child1 = new Personv { Name = "Mary" };
            var child2 = new Personv { Name = "Chris" };

            var relationships = new Relationshipsv();

            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            new Researchv(relationships);//we can access the list in the ctor by jsut exposing the private field as public
        }
    }
}
