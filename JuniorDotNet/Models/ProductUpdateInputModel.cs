using JuniorDotNet.Models;

namespace JuniorDotNet.Controllers
{
    public class ProductUpdateInputModel : Product
    {
        private ProductUpdateInputModel() : base()
        {
        }
        public ProductUpdateInputModel(string name, decimal price) : base(name, price)
        {
        }
    }
}