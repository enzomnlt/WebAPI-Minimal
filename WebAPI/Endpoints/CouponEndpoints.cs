namespace WebAPI.Endpoints
{
    public static class CouponEndpoints
    {
        public static void ConfigureCouponEndPoints(this WebApplication app)
        {
            app.MapGet("/api/coupon", async (ICouponRepository couponRepo, ILogger<Program> logger) =>
            {
                logger.LogInformation("Getting all coupons");
                return Results.Ok(await couponRepo.GetAllAsync());
            }).WithName("GetCoupons").Produces<IEnumerable<Coupon>>(200).RequireAuthorization("Admin");

            app.MapGet("/api/coupon/{id:int}", async (ICouponRepository couponRepo, ILogger<Program> logger, int id) =>
            {
                logger.LogInformation("Getting coupon with id {id}", id);
                return Results.Ok(await couponRepo.GetAsync(id));
            }).WithName("GetCoupon").Produces<Coupon>(200);

            app.MapPost("/api/coupon", async (ICouponRepository couponRepo, IMapper mapper, [FromBody] CouponCreationDTO couponCDTO) =>
            {
                Coupon coupon = mapper.Map<Coupon>(couponCDTO);
                await couponRepo.CreateAsync(coupon);
                await couponRepo.SaveAsync();
                return Results.CreatedAtRoute("GetCoupon", new { id = coupon.Id }, couponCDTO);
            }).WithName("CreateCoupon").Produces<CouponCreationDTO>(201).Produces(400);

            app.MapPut("/api/coupon", async (ICouponRepository couponRepo, IMapper mapper, [FromBody] CouponUpdateDTO couponUDTO) =>
            {
                Coupon coupon = await couponRepo.GetAsync(couponUDTO.Id);
                await couponRepo.UpdateAsync(mapper.Map(couponUDTO, coupon));
                await couponRepo.SaveAsync();
                return Results.Ok(couponUDTO);

            }).WithName("UpdateCoupon").Produces<CouponUpdateDTO>(200).Produces(400);

            app.MapDelete("/api/coupon/{id:int}", async (ICouponRepository couponRepo, int id) =>
            {
                Coupon coupon = await couponRepo.GetAsync(id);
                if (coupon != null)
                {
                    await couponRepo.DeleteAsync(coupon);
                    await couponRepo.SaveAsync();
                    return Results.NoContent();
                }
                return Results.BadRequest("Invalid Id");
            }).WithName("DeleteCoupon");
        }
    }
}
