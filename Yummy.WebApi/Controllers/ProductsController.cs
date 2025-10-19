using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yummy.WebApi.Context;
using Yummy.WebApi.Dtos.ProductDtos;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IValidator<Product> _validator;
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
		public IActionResult ProductList()
		{
			var values = _context.Products.ToList();
			return Ok(values);
		}

		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			var product = _context.Products.Find(id);
			if (product is null)
			{
				return NotFound(new { Message = "Ürün bulunamadı" });
			}
			return Ok(product);
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var value = _context.Products.Include(x => x.Category).ToList();
			return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(value));
		}

		[HttpPost]
		public IActionResult CreateProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}

			_context.Products.Add(product);
			_context.SaveChanges();
			return Ok(new { Message = "Ürün ekleme işlemi başarılı", Data = product });
		}

		[HttpPost("CreateProductWithCategory")]
		public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_context.Products.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme işlemi başarılı.");
		}

		[HttpPut]
		public IActionResult UpdateProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}

			_context.Products.Update(product);
			_context.SaveChanges();
			return Ok(new { Message = "Ürün güncelleme işlemi başarılı", Data = product });
		}

		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var product = _context.Products.Find(id);
			if (product is null)
			{
				return NotFound(new { Message = "Ürün bulunamadı" });
			}
			_context.Products.Remove(product);
			_context.SaveChanges();
			return Ok(new { Message = "Ürün silme işlemi başarılı" });
		}
	}
}
