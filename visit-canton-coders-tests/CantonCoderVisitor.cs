using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace visit_canton_coders_tests
{
    internal class CantonCoderVisitor
    {
        private IEnumerable<Person> potentialListOfPeople;
        internal CantonCoderVisitor(IEnumerable<Person> potentialListOfPeople) {
            this.potentialListOfPeople = potentialListOfPeople;
        }



        internal IEnumerable<Person> getRoute(Person visitor)
        {
            var nextperson = getNextPerson(visitor);
            while(nextperson != null)
            {
                yield return nextperson;
                nextperson = getNextPerson(nextperson);
            }
        }
        private Person getNextPerson(Person person)
        {
            return getNextPerson(person.Location);
        }
        private Person getNextPerson(Location whereAmI)
        {
            return potentialListOfPeople.Where(c => c.Location == whereAmI.NextLocations.SingleOrDefault()).SingleOrDefault();
        }



        internal IEnumerable<Person> getRoute()
        {
            return this.potentialListOfPeople;
        }
    }
}