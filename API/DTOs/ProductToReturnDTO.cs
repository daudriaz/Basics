using Core.Entities;

namespace API.DTOs
{
    public class ProductToReturnDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PicUrl { get; set; }

        public string ProductType { get; set; }
        
        public string ProductBrand { get; set; }
        
    }
}