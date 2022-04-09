using Cars.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Data.Sql.DAOConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<DAO.User>
    {
        public void Configure(EntityTypeBuilder<DAO.User> builder)
        {
            builder.Property(c => c.UserName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Login).IsRequired();
            builder.Property(c => c.Password).IsRequired();
            builder.ToTable("User");
        }
    }

}