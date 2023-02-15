namespace Restaurant.Contracts.Menus;
public record CreateMenuRequest(
        String Title,
        String Description,
        List<MenuSection>  MenuSections);

public record MenuSection(
    String Title,
    String Description,
    List<MenuItem> MenuItems);

public record MenuItem(
    String Title,
    String Description);