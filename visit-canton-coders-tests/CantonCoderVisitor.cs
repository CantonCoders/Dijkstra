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



        internal IEnumerable<Person> getRoute(Person artie)
        {

            var rv = new List<Person>();
            var whereAmI = artie.Location;
            Person nextperson = getNextPerson(whereAmI);

            whereAmI = nextperson.Location;

            var nextnextperson = getNextPerson(whereAmI);
            
            if(nextnextperson==null)
            {
                return new[] { nextperson };
            }
            whereAmI = nextnextperson.Location;

            var nextnextnextperson = getNextPerson(whereAmI);
            
            if(nextnextnextperson == null)
                return new[] { nextperson, nextnextperson, nextnextnextperson };

            whereAmI = nextnextnextperson.Location;

            var nextnextnextnextPerson = getNextPerson(whereAmI);
            return new[] { nextperson, nextnextperson, nextnextnextperson, nextnextnextnextPerson };
           




        }

        private Person getNextPerson(Location whereAmI)
        {
            return potentialListOfPeople.Where(c => c.Location == whereAmI.NextLocation).SingleOrDefault();
        }



        internal IEnumerable<Person> getRoute()
        {
            return this.potentialListOfPeople;
        }
    }
}