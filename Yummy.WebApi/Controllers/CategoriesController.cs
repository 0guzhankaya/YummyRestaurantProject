using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yummy.WebApi.Context;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiContext _context;

		public CategoriesController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return Ok("Kategori ekleme işlemi başarılı.");
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _context.Categories.ToList();
			return Ok(values);
		}

		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return NotFound("Kategori bulunamadı.");
			}
			return Ok(category);
		}

		[HttpPut("UpdateCategory")]
		public IActionResult UpdateCategory(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();
			return Ok("Kategori güncelleme işlemi başarılı.");
		}

		[HttpDelete("DeleteCategory")]
		public IActionResult DeleteCategory(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return NotFound("Kategori bulunamadı.");
			}
			_context.Categories.Remove(category);
			_context.SaveChanges();
			return Ok("Kategori silme işlemi başarılı.");
		}
	}
}
