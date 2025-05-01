namespace all_the_beans.Entities.Models
{
    public class CoffeeBean
    {
        /// <summary>
        /// The unique identifier of the coffee bean.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The index of the coffee bean.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The flag to determine the coffee bean of the day.
        /// </summary>
        public bool IsBeanOfTheDay { get; set; }

        /// <summary>
        /// The url image of the coffee bean.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The colour of the coffee bean.
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// The name of the coffee bean.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the coffee bean.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The country of the coffee bean.
        /// </summary>
        public string Country { get; set; }
    }
}
