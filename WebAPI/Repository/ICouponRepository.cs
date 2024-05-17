namespace WebAPI.Repository
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<Coupon> GetAsync(int id);
        Task CreateAsync(Coupon coupon);
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(Coupon coupon);
        Task SaveAsync();
    }
}
