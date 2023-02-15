using Mapster;
using Restaurant.Application.Menus.Commands.CreateMenu;
using Restaurant.Contracts.Menus;
using Restaurant.Domain.Menu;
using MenuSection = Restaurant.Domain.Menu.Entities.MenuSection;
using MenuItem = Restaurant.Domain.Menu.Entities.MenuItem;

namespace Restaurant.Api.Common.Mapping;
public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string hosiId), CreateMenuCommand>()
              .Map(dest => dest.HostId, src => src.hosiId)
              .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
             .Map(dest => dest.Id, src => src.Id.Value)
             .Map(dest => dest.HostId, src => src.HostId.Value)
             .Map(dest => dest.averageRating, src => src.AverageRating.AvrRatingValue)
             .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))             
             .Map(dest => dest.MenuReviewsIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value))
             .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value)); 

        config.NewConfig<MenuSection, MenuSectionResponse>()
             .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
             .Map(dest => dest.Id, src => src.Id.Value);
    }
}