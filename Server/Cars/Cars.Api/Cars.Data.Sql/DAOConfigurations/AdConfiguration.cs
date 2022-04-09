using Cars.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Data.Sql.DAOConfigurations
{
    public class AdConfiguration: IEntityTypeConfiguration<DAO.Ad>
    {
        public void Configure(EntityTypeBuilder<DAO.Ad> builder)
        {
            //builder.Property(c => c.ObservAd).IsRequired();
          //  builder.Property(c => c.Medias).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.Ads)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Ads)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.CategoryId);
            builder.ToTable("Ad");
        }
    }

}