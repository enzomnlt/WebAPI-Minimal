namespace WebAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;

        public CouponRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Coupon coupon)
        {
            await _db.AddAsync(coupon);
        }

        public async Task DeleteAsync(Coupon coupon)
        {
            _db.Coupons.Remove(coupon);
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            return await _db.Coupons.ToListAsync();
        }

        public async Task<Coupon> GetAsync(int id)
        {
            return await _db.Coupons.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coupon coupon)
        {
            _db.Coupons.Update(coupon);
        }
    }
}
