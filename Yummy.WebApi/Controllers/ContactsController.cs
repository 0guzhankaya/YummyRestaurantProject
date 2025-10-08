using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yummy.WebApi.Context;
using Yummy.WebApi.Dtos.ContactDtos;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ContactsController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _context.Contacts.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto contactDto)
		{
			// Manual Mapping
			Contact contact = new Contact()
			{
				MapLocation = contactDto.MapLocation,
				Address = contactDto.Address,
				PhoneNumber = contactDto.PhoneNumber,
				Email = contactDto.Email,
				OpenHours = contactDto.OpenHours
			};

			_context.Contacts.Add(contact);
			_context.SaveChanges();
			return Ok("Ekleme işlemi başarılı.");
		}

		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			var value = _context.Contacts.Find(id);
			if (value == null)
			{
				return NotFound();
			}
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto contactDto)
		{
			var value = _context.Contacts.Find(contactDto.ContactId);
			if (value == null)
			{
				return NotFound();
			}
			// Manual Mapping
			value.MapLocation = contactDto.MapLocation;
			value.Address = contactDto.Address;
			value.PhoneNumber = contactDto.PhoneNumber;
			value.Email = contactDto.Email;
			value.OpenHours = contactDto.OpenHours;
			_context.Contacts.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme işlemi başarılı.");
		}

		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return Ok("Silme işlemi başarılı.");
		}
	}
}
