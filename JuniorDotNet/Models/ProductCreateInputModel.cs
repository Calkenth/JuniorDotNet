using JuniorDotNet.Models;

namespace JuniorDotNet.Controllers
{
    public class ProductCreateInputModel : Product
    {
        private ProductCreateInputModel() : base()
        {
        }
        public ProductCreateInputModel(string name, decimal price) : base(name, price)
        {
        }
    }
}