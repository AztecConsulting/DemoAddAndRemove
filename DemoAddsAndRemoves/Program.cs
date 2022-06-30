using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DemoAddsAndRemoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Detecting Adds and Removals!");

            var ListA = new List<SampleRec>();
            var ListB = new List<SampleRec>();

            ListA.Add(new SampleRec { Name = "Joe", IsMember = true, ID=1 });
            ListA.Add(new SampleRec { Name = "Jan", IsMember = true, ID = 2 });
            ListA.Add(new SampleRec { Name = "Josh", IsMember = false, ID = 3 });
            ListA.Add(new SampleRec { Name = "Jester", IsMember = false, ID = 4 });

            ListB.Add(new SampleRec { Name = "Joe", IsMember = true, ID = 1 });
            ListB.Add(new SampleRec { Name = "Jan", IsMember = false, ID = 2 });
            ListB.Add(new SampleRec { Name = "Josh", IsMember = false, ID = 3 });
            ListB.Add(new SampleRec { Name = "Jester", IsMember = true, ID = 4 });

            //Identify the chosen
            var selectedA = ListA.Where(c => c.IsMember == true).Select(o => o.ID).ToArray<int>();
            var selectedB = ListB.Where(c => c.IsMember == true).Select(o => o.ID).ToArray<int>();
            
            //Who are the exceptions?
            var added = selectedB.Except(selectedA).ToList();
            var removed = selectedA.Except(selectedB).ToList();

            //Work the changes
            foreach (var item in added)
            {
                Debug.WriteLine($"Added {item}");
                //Logic to Add User ID
            }
            foreach (var item in removed)
            {
                Debug.WriteLine($"Removed {item}");
                //Logic to Remove user ID
            }

        }



        public class SampleRec
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsMember { get; set; }
        }
    }
}
