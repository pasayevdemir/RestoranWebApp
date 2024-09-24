using Core.Constants;
using Entity.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AboutCounfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");

            builder.Property(x => x.ID)
                .UseIdentityColumn(
                        seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE,
                        increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Deleted)
                .HasDefaultValue(DefaultConstantValues.DEFAULT_DELETED_COLUMN_VALUE);
        }
    }
}
