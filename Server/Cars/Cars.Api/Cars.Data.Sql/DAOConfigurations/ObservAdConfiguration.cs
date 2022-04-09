using Cars.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Data.Sql.DAOConfigurations
{
    public class ObservAdConfiguration: IEntityTypeConfiguration<ObservAd>
    {
        public void Configure(EntityTypeBuilder<ObservAd> builder)
        {
            builder.HasOne(x=> x.User)
                .WithMany(x => x.ObservAds)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x=> x.Ad)
                .WithMany(x => x.ObservAd)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AdId);
        }
    }

}