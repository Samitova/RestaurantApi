using Restaurant.Domain.Common.Models;
using Restaurant.Domain.DinnerAggregate.ValueObjects;

namespace Restaurant.Domain.DinnerAggregate.Entities;
public sealed class Location : Entity<LocationId>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }    

    private Location(
        LocationId locationId,
        string name,
        string address,
        decimal latitude,
        decimal longitude)
        : base(locationId)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(
        string name,
        string address,
        decimal latitude,
        decimal longitude
        )
    {
        return new(
            LocationId.CreateUnique(),
            name,
            address,
            latitude,
            longitude);
    }
}
