using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace all_the_beans.Entities.Models
{
    public class CoffeeBeanTable
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
        /// The cost of the coffee bean.
        /// NOTE: I've decided to represent this as a decimal as potentially we could need to perform some currency conversion for beans.
        /// This is just some consideration/thought process.
        /// </summary>
        public decimal Cost { get; set; }

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
