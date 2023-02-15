using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.Menu;
using Restaurant.Domain.Menu.Entities;
using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Infrastructure.Persistence.Configurations;
public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfiguesMenuTable(builder);
        ConfiguesMenuSectionsTable(builder);
        ConfiguesMenuDinnerIdsTable(builder);
        ConfiguesMenuReviewIdsTable(builder);
    }

    private void ConfiguesMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");
            dib.WithOwner().HasForeignKey("MenuId");

            dib.HasKey("Id");

            dib.Property(p => p.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();            
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private void ConfiguesMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(p => p.MenuReviewIds, rib =>
        {
            rib.ToTable("MenuReviewIds");
            rib.WithOwner().HasForeignKey("MenuId");
            rib.HasKey("Id");
            rib.Property(p => p.Value)
            .HasColumnName("ReviewIds")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfiguesMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(s => s.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.HasKey(nameof(MenuSection.Id), "MenuId");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.Property(p => p.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuSectionId.Create(value));

            sb.Property(p => p.Title)
            .HasMaxLength(100);

            sb.Property(p => p.Description)
            .HasMaxLength(100);

            sb.OwnsMany(i => i.Items, ib =>
            {
                ib.ToTable("MenuItems");
                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");
                ib.WithOwner().HasForeignKey("MenuId", "MenuSectionId");

                ib.Property(p => p.Id)
                .HasColumnName("MenuItemId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value));
            });

            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfiguesMenuTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => MenuId.Create(value));

        builder.Property(p => p.Title)
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(100);

        builder.OwnsOne(p => p.AverageRating, ab => {
            ab.Property(k => k.AvrRatingValue)
            .HasColumnName("AvrRatingValue");
            ab.Property(k => k.AvrRatingCount)
            .HasColumnName("AvrRatingCount");
        });

        builder.Property(p => p.HostId)
            .HasConversion(
            hostId => hostId.Value,
            value => HostId.Create(value));
    }

}
