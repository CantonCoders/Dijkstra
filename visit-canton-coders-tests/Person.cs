namespace visit_canton_coders_tests
{
    internal class Person
    {
        public Location Location { get; private set; }

        public Person(Location location)
        {
            this.Location = location;
        }
    }
}