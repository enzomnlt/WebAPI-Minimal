using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO
{
    public class CouponCreationDTO
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public bool IsActive { get; set; }
    }
}
