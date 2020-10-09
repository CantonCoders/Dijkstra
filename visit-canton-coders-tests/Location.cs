using System.Collections.Generic;

namespace visit_canton_coders_tests
{
    internal class Location
    {
        private string v;

        public IEnumerable<Location> NextLocations { get; private set; }
        public Location(string v)
        {
            this.v = v;
            this.NextLocations = new Location[] { };
        }

        public Location(string v, Location nextLocation) : this(v)
        {
            this.v = v;
            this.NextLocations = new[] { nextLocation };
        }

        public Location(string v, Location[] locations) : this(v)
        {
            this.NextLocations = locations;
        }
    }
}