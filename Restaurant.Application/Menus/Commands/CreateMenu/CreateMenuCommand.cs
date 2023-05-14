using ErrorOr;
using MediatR;
using Restaurant.Domain.MenuAggregate;

namespace Restaurant.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
        string HostId,
        string Title,
        string Description,
        List<MenuSectionCommand> MenuSections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Title,
    string Description,
    List<MenuItemCommand> MenuItems);

public record MenuItemCommand(
    string Title,
    string Description);
