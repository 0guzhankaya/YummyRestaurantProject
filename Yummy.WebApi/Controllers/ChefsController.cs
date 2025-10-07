using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yummy.WebApi.Context;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChefsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ChefsController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult ChefList()
		{
			var values = _context.Chefs.ToList();
			return Ok(values);
		}

		[HttpGet("GetChef")]
		public IActionResult GetChef(int id)
		{
			var chef = _context.Chefs.Find(id);
			if (chef == null)
			{
				return NotFound("Şef bulunamadı.");
			}
			return Ok(chef);
		}

		[HttpPost]
		public IActionResult CreateChef(Chef chefs)
		{
			_context.Chefs.Add(chefs);
			_context.SaveChanges();
			return Ok("Şef ekleme işlemi başarılı.");
		}

		[HttpPut]
		public IActionResult UpdateChef(Chef chefs)
		{
			_context.Chefs.Update(chefs);
			_context.SaveChanges();
			return Ok("Şef güncelleme işlemi başarılı.");
		}

		[HttpDelete]
		public IActionResult DeleteChef(int id)
		{
			var chef = _context.Chefs.Find(id);
			if (chef == null)
			{
				return NotFound("Şef bulunamadı.");
			}
			_context.Chefs.Remove(chef);
			_context.SaveChanges();
			return Ok("Şef silme işlemi başarılı.");
		}
	}
}
