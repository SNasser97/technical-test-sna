﻿namespace all_the_beans.Entities.Queries.V1.GetCoffeeBeansQuery
{
    public record GetCoffeeBeansQueryRequest(int Page, int ItemsPerPAge, string Colour)
    {
    }
}