﻿using Mapster;
using Restaurant.Application.Menus.Commands.CreateMenu;
using Restaurant.Contracts.Menus;
using Restaurant.Domain.MenuAggregate;
using MenuSection = Restaurant.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = Restaurant.Domain.MenuAggregate.Entities.MenuItem;

namespace Restaurant.Api.Common.Mapping;
public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
              .Map(dest => dest.HostId, src => src.hostId)
              .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
             .Map(dest => dest.Id, src => src.Id.Value)
             .Map(dest => dest.HostId, src => src.HostId.Value)
             .Map(dest => dest.AverageRating, src => src.AverageRating.AvrRatingValue)
             .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
             .Map(dest => dest.MenuReviewsIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));


        config.NewConfig<MenuSection, MenuSectionResponse>()
                 .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
             .Map(dest => dest.Id, src => src.Id.Value);
    }
}