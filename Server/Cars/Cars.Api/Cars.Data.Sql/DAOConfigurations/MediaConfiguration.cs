using Cars.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Data.Sql.DAOConfigurations
{
    public class MediaConfiguration: IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasOne(x => x.Ad)
                .WithMany(x => x.Medias)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AdId);
            builder.ToTable("Media");
        }
    }
}