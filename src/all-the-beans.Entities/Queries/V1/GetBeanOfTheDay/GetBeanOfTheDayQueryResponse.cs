namespace all_the_beans.Entities.Queries.V1.GetBeanOfTheDay
{
    public partial record GetBeanOfTheDayQueryResponse
    {
        public string Id { get; set; }

        public decimal Cost { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Colour { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }
    }
}
