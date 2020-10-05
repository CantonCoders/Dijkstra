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

            var whereAmI = artie.Location;
            foreach (var person in potentialListOfPeople)
            {
                yield return nextPerson(artie);
            }

        }

        private Person nextPerson(Person next)
        {
            var whereAmI = next.Location;
            foreach (var person in potentialListOfPeople)
            {

                if (person.Location == whereAmI.NextLocation)
                {
                    whereAmI = person.Location;
                   return person;
                }
            }
            throw new NotImplementedException();
        }



        internal IEnumerable<Person> getRoute()
        {
            return this.potentialListOfPeople;
        }
    }
}