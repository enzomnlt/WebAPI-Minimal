namespace WebAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
            new Coupon()
            {
                Id = 1,
                Name = "Coupon 1",
                Percentage = 10,
                IsActive = true,
                Created = DateTime.Now
            },
            new Coupon()
            {
                Id = 2,
                Name = "Coupon 2",
                Percentage = 20,
                IsActive = true,
                Created = DateTime.Now
            });
        }

    }
}
