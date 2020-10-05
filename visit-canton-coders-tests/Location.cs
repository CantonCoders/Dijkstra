namespace visit_canton_coders_tests
{
    internal class Location
    {
        private string v;
        public Location NextLocation { get; private set; }

        public Location(string v)
        {
            this.v = v;
        }

        public Location(string v, Location nextLocation) : this(v)
        {
            NextLocation = nextLocation;
        }
    }
}