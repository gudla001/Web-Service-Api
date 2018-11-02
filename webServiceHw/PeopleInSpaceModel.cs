using System;
using System.Collections.Generic;

namespace webServiceHw
{
    public class PeopleInSpaceModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
        public int Number { get; set; }
    }



    public class Person
    {
        public string Name { get; set; }
        public string Craft { get; set; }
    }
}
