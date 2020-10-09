using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace visit_canton_coders_tests
{
    /*
     * The Shortest Path Algorithm.

        Canton Coders are located around the world. For 2021, we would like to visit every coder IRL. To do this, we must determine the shortest path between each community member's house. 
        Keep in mind, when a community member lives with another community member, it ten times more valuable to visit those community members. 
        The distance between each members is measured in minutes, 
        and the goal is to visit the most community members in 30 calendar days.

        You must write a piece of software that can read from 2 CSVs and will output a route for the most valuable travel route. 
        The input files are as follows:

        members.csv (name,location)
        locations (currentlocation,connectinglocation,timeoftravel)
        The output file should be a list of names in priority order for the most valuable route.
     * 
     * 
     */
    public class UnitTest1
    {
        [Fact
            ]
        public void JoelGoVisitMatt()
        {
            var locationconnectedtocanton = new Location("Belleville");
            var canton = new Location("Canton", locationconnectedtocanton);

            var joel = new Person(canton);

            var matt = new Person(locationconnectedtocanton);

            CantonCoderVisitor visitor = new CantonCoderVisitor(new[] { matt});
            visitor.getRoute(joel).Should().ContainInOrder(new[] { matt });
        }
        [Fact]
        public void ArtieGoVisit_JoelMatt()
        {
            var birmingham = new Location("Birmingham");
            var canton = new Location("Canton", birmingham);
            var austin = new Location("Austin", canton);



            var joel = new Person(canton);
            var artie = new Person(austin);
            var matt = new Person(birmingham);


            CantonCoderVisitor visitor = new CantonCoderVisitor(new[] { joel, artie, matt });
            visitor.getRoute(artie).Should().ContainInOrder(new[] { joel, matt });
        }
       

       [Fact]
        public void Artie_GoVisitBryanMattAndJoelInThatOrder()
        {
            var birmingham = new Location("Birmingham");
            var canton = new Location("Canton", birmingham);
            var bentonville = new Location("Bentonville", canton);
            var austin = new Location("Austin", bentonville);

            var artie = new Person(austin);
            var joel = new Person(canton);
            var matt = new Person(birmingham);
            var bryan = new Person(bentonville);

            CantonCoderVisitor visitor = new CantonCoderVisitor(new[] { joel, matt,bryan });
            visitor.getRoute(artie).Should().ContainInOrder(new[] { bryan, joel, matt });

        }

        [Fact]
        public void Artie_GoVisitBryanMattJoelBennyButNotJimInThatOrder()
        {
            var nyc = new Location("nyc");
            var island = new Location("island");
            var birmingham = new Location("Birmingham",nyc);
            var canton = new Location("Canton", birmingham);
            var bentonville = new Location("Bentonville", canton);
            var austin = new Location("Austin", bentonville);
           
            
            var benny = new Person(nyc);
            var jim = new Person(island);
            var artie = new Person(austin);
            var joel = new Person(canton);
            var matt = new Person(birmingham);
            var bryan = new Person(bentonville);

            CantonCoderVisitor visitor = new CantonCoderVisitor(new[] { benny,joel, jim, matt, bryan });
            visitor.getRoute(artie).Should().ContainInOrder(new[] { bryan, joel, matt, benny });

        }






        [Fact]
        public void Test_People()
        {
            var nextLocation = new Location("Texas");
            var location = new Location("Hollywoo", new Location[] { nextLocation });

            location.NextLocations.Should().ContainInOrder(new[] { nextLocation });
            Person person = new Person(location);
            person.Location.Should().Be(location);
            person.Should().NotBeNull();


        }


    }
}
