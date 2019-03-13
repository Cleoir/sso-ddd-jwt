using SSO.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SSO.Infra.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("TB_USER");

            HasKey(id => id.Id);

            Property(user => user.Name).HasMaxLength(256).IsRequired();
            Property(password => password.Password).HasMaxLength(256).IsRequired();
            Property(permission => permission.Role).HasMaxLength(80).IsRequired();
        }
    }
}
