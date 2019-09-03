using System;
using System.Linq;
using JuniorDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuniorDotNet.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }


        // GET api/product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (_context.Products.Count() == 0)
                {
                    throw new Exception("No products in database.");
                }
                return Ok(_context.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        // GET api/product/GUID id
        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            try
            {
                var product = _context.GetProduct(id);
                if (product == null)
                {
                    throw new Exception("Wrong Id! Product doesn't exist.");
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody]ProductCreateInputModel product)
        {
            try
            {
                if (product == null)
                {
                    throw new Exception("Sent object is null");
                }
                else
                {
                    ProductCreateInputModel newProduct = new ProductCreateInputModel(product.Name, product.Price);
                    if (product.Price == 0)
                    {
                        throw new Exception("Price value have to be above 0.");
                    }
                    else if (!ModelState.IsValid)
                    {
                        throw new Exception(ModelState.ValidationState + " object status. Name cannot be null and must have between 1 and 100 characters, price have to be above 0.");
                    }
                    else
                    {
                        _context.Products.Add(newProduct);
                        _context.SaveChanges();

                        return Ok(newProduct.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }


        // PUT api/product/GUID id
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]ProductUpdateInputModel product)
        {
            try
            {
                product.Id = id;
                var oldProduct = _context.GetProduct(id);
                if (oldProduct == null)
                {
                    throw new Exception("Wrong Id! Product doesn't exist.");
                }
                else if (product.Price == 0)
                {
                    throw new Exception("Price value have to be above 0.");
                }
                else if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ValidationState + " object status. Name cannot be null and must have between 1 and 100 characters, price have to be above 0.");
                }
                else
                {
                    _context.Entry(oldProduct).CurrentValues.SetValues(product);
                    _context.SaveChanges();

                    return Ok("Product updated.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        // DELETE api/product/GUID id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _context.GetProduct(id);
                if (product == null)
                {
                    throw new Exception("Wrong Id! Product doesn't exist.");
                }
                else
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();

                    return Ok("Product " + product.Name + " deleted.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }
    }
}