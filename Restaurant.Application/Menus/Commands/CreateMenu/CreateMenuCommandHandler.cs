using ErrorOr;
using MediatR;
using Restaurant.Application.Common.Interfaces.Persistence;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.MenuAggregate;
using Restaurant.Domain.MenuAggregate.Entities;

namespace Restaurant.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(            
            request.Title,
            request.Description,
            request.MenuSections.ConvertAll(section => MenuSection.Create(
                section.Title,
                section.Description,
                section.MenuItems.ConvertAll(item => MenuItem.Create(item.Title, item.Description)))),
            HostId.Create(request.HostId)
            );
      
        _menuRepository.Add(menu);
       
        return menu;
    }
}
