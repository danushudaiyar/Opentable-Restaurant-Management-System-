// Models/RestaurantFilters.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Models
{
public class RestaurantFilters
{
    public RestaurantFilters(string filterstring)
    {
        FilterString = filterstring ?? "all-all-all";
        string[] filters = FilterString.Split('-');
        MetropolisId = filters[0];
        PriceRange = filters[1];
        CuisineStyle = filters[2];
    }

    public string FilterString { get; }
    public string MetropolisId { get; }
    public string PriceRange { get; }
    public string CuisineStyle { get; }

    public bool HasMetropolis => MetropolisId != "all";
    public bool HasPriceRange => PriceRange != "all";
    public bool HasCuisineStyle => CuisineStyle != "all";
}
}