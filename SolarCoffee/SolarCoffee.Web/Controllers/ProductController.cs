﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Product;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger,
      IProductService productService)
    {
      _logger = logger;
      _productService = productService;
    }

    [HttpPost("/api/product")]
    public ActionResult AddProduct([FromBody] ProductModel product)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _logger.LogInformation("Adding product");
      var newProduct = ProductMapper.SerializeProductModel(product);
      var newProductResponse = _productService.CreateProduct(newProduct);
      return Ok(newProductResponse);
    }

    [HttpGet("/api/product")]
    public ActionResult GetProduct()
    {
      _logger.LogInformation("Getting all products");
      var products = _productService.GetAllProducts();
      var productViewModels = products
        .Select(ProductMapper.SerializeProductModel);
      return Ok(productViewModels);
    }

    [HttpPatch("/api/product/{id}")]
    public ActionResult ArchiveProduct(int id)
    {
      _logger.LogInformation("Archiving product");
      var archiveResult = _productService.ArciveProduct(id);
      return Ok(archiveResult);
    }
  }
}
