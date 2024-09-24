using Core.Constants;
using Entity.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AboutPhotoConfiguration : IEntityTypeConfiguration<AboutPhoto>
    {
        public void Configure(EntityTypeBuilder<AboutPhoto> builder)
        {
            builder.ToTable("Abouts");

            builder.Property(x => x.ID)
                .UseIdentityColumn(
                        seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE,
                        increment: 1);

            builder.Property(x => x.ImgUrl)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Deleted)
                .HasDefaultValue(DefaultConstantValues.DEFAULT_DELETED_COLUMN_VALUE);

            builder.HasOne(aF => aF.About)
                .WithMany(a => a.AboutPhotos)
                .HasForeignKey(aF => aF.AboutId);
        }
    }
}
