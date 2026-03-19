// // using Microsoft.AspNetCore.Mvc;
// // using MyApi.Models;
// // using MyApi.Repository;

// // namespace MyApi.Controllers
// // {
// //     [ApiController]
// //     [Route("api/[controller]")]
// //     public class ProductController : ControllerBase
// //     {
// //         private static Repository<Product> _repo = new Repository<Product>();

// //         [HttpGet]
// //         public IActionResult GetAll()
// //         {
// //             return Ok(_repo.GetAll());
// //         }

// //         [HttpPost]
// //         public IActionResult Add(Product product)
// //         {
// //             _repo.Add(product);
// //             return Ok(product);
// //         }

// //         [HttpDelete("{id}")]
// //         public IActionResult Delete(int id)
// //         {
// //             _repo.Delete(id);
// //             return Ok("Deleted");
// //         }
// //     }
// // }
// using Microsoft.AspNetCore.Mvc;
// using MyApi.Models;
// using MyApi.Repository;

// namespace MyApi.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ProductController : ControllerBase
//     {
//         //private static Repository<Product> _repo = new Repository<Product>();
//         private readonly ProductRepository _repo;

//         public ProductController(ProductRepository repo)
//         {
//             _repo = repo;
//         }
//         // ✅ GET ALL
//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             try
//             {
//                 var data = _repo.GetAll();

//                 if (data == null || data.Count == 0)
//                 {
//                     return NotFound(new
//                     {
//                         message = "No products found"
//                     });
//                 }

//                 return Ok(new
//                 {
//                     message = "Products fetched successfully",
//                     data = data
//                 });
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, new
//                 {
//                     message = "Something went wrong",
//                     error = ex.Message
//                 });
//             }
//         }

//         // ✅UPDATE PRODUCT
//         [HttpPut("{id}")]
//         public IActionResult Update(int id, Product product)
//         {
//             try
//             {
//                 var existing = _repo.GetById(id);
//                 if (existing == null)
//                 {
//                     return NotFound(new
//                     {
//                         message = $"Product with ID {id} not found"
//                     });
//                 }
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, new
//                 {
//                     message = "Error while updating product",
//                     error = ex.Message
//                 });
//             }
//             _repo.Update(id, product);
//             return Ok(new
//             {
//                 message = "Product updated successfully",
//                 data = product
//             });
//         }


//         // ✅ ADD PRODUCT
//         [HttpPost]
//         public IActionResult Add(Product product)
//         {
//             try
//             {
//                 if (product == null)
//                 {
//                     return BadRequest(new
//                     {
//                         message = "Product data is required"
//                     });
//                 }

//                 if (string.IsNullOrEmpty(product.Name))
//                 {
//                     return BadRequest(new
//                     {
//                         message = "Product name is required"
//                     });
//                 }

//                 _repo.Add(product);

//                 return Ok(new
//                 {
//                     message = "Product added successfully",
//                     data = product
//                 });
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, new
//                 {
//                     message = "Error while adding product",
//                     error = ex.Message
//                 });
//             }
//         }

//         // ✅ DELETE PRODUCT
//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             try
//             {
//                 var existing = _repo.GetById(id);

//                 if (existing == null)
//                 {
//                     return NotFound(new
//                     {
//                         message = $"Product with ID {id} not found"
//                     });
//                 }

//                 _repo.Delete(id);

//                 return Ok(new
//                 {
//                     message = "Product deleted successfully"
//                 });
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, new
//                 {
//                     message = "Error while deleting product",
//                     error = ex.Message
//                 });
//             }
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Repository;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProductController(IRepository repo)
        {
            _repo = repo;
        }

        // ✅ GET ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _repo.GetAll();

                if (data == null || data.Count == 0)
                {
                    return NotFound(new
                    {
                        message = "No products found"
                    });
                }

                return Ok(new
                {
                    message = "Products fetched successfully",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Something went wrong",
                    error = ex.Message
                });
            }
        }

        // ✅ UPDATE PRODUCT
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            try
            {
                var existing = _repo.GetById(id);

                if (existing == null)
                {
                    return NotFound(new
                    {
                        message = $"Product with ID {id} not found"
                    });
                }

                _repo.Update(id, product);

                return Ok(new
                {
                    message = "Product updated successfully",
                    data = product
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while updating product",
                    error = ex.Message
                });
            }
        }

        // ✅ ADD PRODUCT
        [HttpPost]
        public IActionResult Add(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest(new
                    {
                        message = "Product data is required"
                    });
                }

                if (string.IsNullOrEmpty(product.Name))
                {
                    return BadRequest(new
                    {
                        message = "Product name is required"
                    });
                }

                _repo.Add(product);

                return Ok(new
                {
                    message = "Product added successfully",
                    data = product
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while adding product",
                    error = ex.Message
                });
            }
        }

        // ✅ DELETE PRODUCT
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existing = _repo.GetById(id);

                if (existing == null)
                {
                    return NotFound(new
                    {
                        message = $"Product with ID {id} not found"
                    });
                }

                _repo.Delete(id);

                return Ok(new
                {
                    message = "Product deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while deleting product",
                    error = ex.Message
                });
            }
        }
    }
}