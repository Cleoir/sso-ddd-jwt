namespace SSO.Infra.Migrations
{
    using SSO.Domain.Entity;
    using SSO.Infra.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SsoDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SsoDataContext context)
        {
            context.Users.Add(new User { Id = 1, Name = "Mary John", Password = "Ste@456", Role = "Admin" });
            context.Users.Add(new User { Id = 2, Name = "John Boran", Password = "Ste@901", Role = "Manager" });
            context.Users.Add(new User { Id = 3, Name = "Jenifer Philips", Password = "Ste@678", Role = "User" });
            context.SaveChanges();
        }
    }
}
