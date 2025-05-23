﻿using all_the_beans.Entities.Entity.CoffeeBean;

namespace all_the_beans.Data.Tables.CoffeeBeanTable
{
    /// <summary>
    /// CoffeeBeanTable class represents the structure of the coffee bean table in the database.
    /// </summary>
    public partial class CoffeeBeanTable
    {
        public static CoffeeBeanTable ToCoffeeBeanTable(CoffeeBean coffeeBean)
        {
            return new CoffeeBeanTable
            {
                Id = coffeeBean.Id,
                Index = coffeeBean.Index,
                IsBeanOfTheDay = coffeeBean.IsBeanOfTheDay,
                Cost = coffeeBean.Cost,
                Image = coffeeBean.Image,
                Colour = coffeeBean.Colour,
                Name = coffeeBean.Name,
                Description = coffeeBean.Description,
                Country = coffeeBean.Country
            };
        }

        public static CoffeeBean ToCoffeeBeanEntity(CoffeeBeanTable coffeeBeanTable)
        {
            return new CoffeeBean
            {
                Id = coffeeBeanTable.Id,
                Index = coffeeBeanTable.Index,
                IsBeanOfTheDay = coffeeBeanTable.IsBeanOfTheDay,
                Cost = coffeeBeanTable.Cost,
                Image = coffeeBeanTable.Image,
                Colour = coffeeBeanTable.Colour,
                Name = coffeeBeanTable.Name,
                Description = coffeeBeanTable.Description,
                Country = coffeeBeanTable.Country
            };
        }
    }
}
