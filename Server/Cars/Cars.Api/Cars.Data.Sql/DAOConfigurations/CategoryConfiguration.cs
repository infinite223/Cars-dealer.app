using Cars.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Data.Sql.DAOConfigurations
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryId).IsRequired();
            builder.Property(c => c.NameCategory).IsRequired();
            builder.ToTable("Category");
        }
    }

}