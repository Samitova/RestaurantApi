using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Domain.MenuAggregate.Entities;

public class AverageRating
{
    public float AvrRatingValue { get; set; }
    public int AvrRatingCount { get; set; }
    private AverageRating(float value, int count)
    {
        AvrRatingValue = value;
        AvrRatingCount = count;
    }

    public static AverageRating Create(float value, int count)
    {
        return new(value, count);
    }

    private AverageRating()
    {        
    }
}
