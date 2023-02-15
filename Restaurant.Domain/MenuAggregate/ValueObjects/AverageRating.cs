using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Domain.MenuAggregate.ValueObjects;

public class AverageRating
{
    public float AvrRatingValue { get; set; }
    public int AvrRatingCount { get; set; }
    public AverageRating(float value, int count)
    {
        AvrRatingValue = value;
        AvrRatingCount = count;
    }   
}
