namespace Restaurant.Contracts.Menus;

public record MenuResponse(
    string Id,
    String Title,
    String Description, 
    float AverageRating,
    List<MenuSectionResponse> Sections, 
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewsIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record MenuSectionResponse(
    string Id,
    String Title,
    String Description,
    List<MenuItemResponse> Items);

public record MenuItemResponse(
    string Id,
    String Title,
    String Description);
